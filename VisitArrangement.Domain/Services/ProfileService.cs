namespace VisitArrangement.Domain.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Entities;
using VisitArrangement.Infrastructure.Context;

public class ProfileService : IProfileService
{
    private VisitArrangementDbContext _context;

    public ProfileService(VisitArrangementDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserProfileDto>> GetUserProfilesAsync(int userId, string? search, int? minRating)
    {
        List<User> usersQuery = await _context.Users
            .Include(x => x.Reviews)
            .Include(x => x.UserLocations)  // Ensure locations are included
                .ThenInclude(ul => ul.Location)
            .Where(x => x.Id != userId)
            .ToListAsync();

        // Filter by minimum rating
        if (minRating.HasValue && minRating > 0)
        {
            usersQuery = usersQuery.Where(x => (x.Reviews.Any() ? x.Reviews.Average(r => r.Rating) : 0) >= minRating).ToList();
        }

        List<UserProfileDto> users = usersQuery
            .Select(x => new UserProfileDto(
                x.Id,
                x.FirstName,
                x.LastName,
                x.Email,
                x.ProfilePicture,
                x.Reviews.Any() ? x.Reviews.Average(r => r.Rating) : 0,
                new List<LocationDto>()))
            .ToList();

        var userIds = users.Select(x => x.Id).ToHashSet();

        // Get locations for filtered users
        var res = (await _context.UserLocations
            .Include(x => x.Location)
            .ThenInclude(x => x.Images)
            .Where(x => userIds.Contains(x.UserFK) && x.DeletedOn == null)
            .ToListAsync())
            .GroupBy(x => x.UserFK)
            .ToDictionary(
                x => x.Key,
                v => v.Select(x => new LocationDto(
                    x.LocationFK,
                    x.Location.Name,
                    x.Location.Images.Select(y => y.Path).ToList())));

        // Assign locations to users
        foreach (UserProfileDto user in users.Where(x => res.ContainsKey(x.Id)))
        {
            user.Locations = res[user.Id].ToList();
        }

        // Filter by name or location (case-insensitive)
        if (!string.IsNullOrEmpty(search))
        {
            string searchLower = search.ToLower();

            users = users.Where(x =>
                x.FirstName.ToLower().Contains(searchLower) ||
                x.LastName.ToLower().Contains(searchLower) ||
                x.Locations.Any(l => l.Name.ToLower().Contains(searchLower))
            ).ToList();
        }

        return users;
    }




    public async Task<UserProfileDto> GetUserProfileAsync(int userId, int otherUserId)
    {
        UserProfileDto user = await _context.Users
            .Include(x => x.Reviews)
            .Where(x => x.Id == otherUserId && x.DeletedOn == null)
            .Select(x => new UserProfileDto(x.Id, x.FirstName, x.LastName, x.Email, x.ProfilePicture, x.Reviews.Average(r => r.Rating), new List<LocationDto>()))
            .FirstAsync();

        user.Locations = await _context.UserLocations
            .Include(x => x.Location)
            .ThenInclude(x => x.Images)
            .Where(x => x.UserFK == otherUserId && x.DeletedOn == null)
            .Select(x => new LocationDto(x.LocationFK, x.Location.Name, x.Location.Images.Select(y => y.Path).ToList()))
            .ToListAsync();

        Tuple<bool, bool>? arrangement = await _context.Arrangements
            .Include(x => x.Reviews)
            .Where(x => (x.HostFK == userId && x.VisitorFK == otherUserId) || (x.VisitorFK == userId && x.HostFK == otherUserId))
            .Select(x => Tuple.Create(x.ApprovedByHost && x.ApprovedByVisitor, x.Reviews.Any(r => r.ByUserFK == userId)))
            .FirstOrDefaultAsync();

        user.Reviews = await _context.Reviews
            .Include(x => x.ByUser)
            .Where(x => x.ForUserFK == otherUserId)
            .Select(x => new ReviewDto(x.ByUser.FirstName, x.ByUser.LastName, x.ByUser.ProfilePicture, x.Rating, x.Comment))
            .ToListAsync();

        user.VisitArranged = arrangement?.Item1 ?? false;
        user.Rated = arrangement?.Item2 ?? false;

        return user;
    }

    public async Task<User> UpdateUserProfileAsync([FromRoute] int userId, [FromBody] UserProfileDto userProfileDto)
    {
        User user = await _context.Users
            .Where(x => x.Id == userId && x.DeletedOn == null)
            .FirstAsync();

        user.FirstName = userProfileDto.FirstName;
        user.LastName = userProfileDto.LastName;
        user.ProfilePicture = userProfileDto.ProfilePicture;

        List<int> existingUserLocations = await _context.UserLocations
            .Where(x => x.UserFK == userId && x.DeletedOn == null)
            .Select(x => x.LocationFK)
            .ToListAsync();
        List<UserLocation> userLocationsToInsert = [];
        foreach (var location in userProfileDto.Locations.Where(x => x.Id == 0))
        {
            Location newLocation = new Location(location.Name);
            _context.Locations.Add(newLocation);
            _context.LocationImages.AddRange(location.Images.Select(x => new LocationImage(newLocation, x)));
            userLocationsToInsert.Add(new UserLocation(newLocation, userId));
        }

        await _context.SaveChangesAsync();

        userLocationsToInsert.AddRange(userProfileDto.Locations
            .Where(x => x.Id != 0 && !existingUserLocations.Contains(x.Id))
            .Select(x => new UserLocation(userId, x.Id)));

        _context.UserLocations.AddRange(userLocationsToInsert);

        DateTime date = DateTime.UtcNow;

        List<int> userLocationsToDelete = existingUserLocations
            .Where(x => !userProfileDto.Locations.Any(y => y.Id == x))
            .ToList();

        foreach (UserLocation userLocation in _context.UserLocations.Where(x => userLocationsToDelete.Contains(x.LocationFK) && x.DeletedOn == null))
        {
            userLocation.DeletedOn = date;
        }

        await _context.SaveChangesAsync();

        return user;
    }
}
