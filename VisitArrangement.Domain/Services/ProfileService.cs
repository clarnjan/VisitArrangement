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

    public async Task<List<UserProfileDto>> GetUserProfilesAsync(int userId)
    {
        List<UserProfileDto> users = await _context.Users
            .Where(x => x.Id != userId)
            .Select(x=> new UserProfileDto(x.Id, x.FirstName, x.LastName, x.Email, x.ProfilePicture, new List<LocationDto>()))
            .ToListAsync();

        var userIds = users.Select(x => x.Id).ToHashSet();

        Dictionary<int, IEnumerable<LocationDto>> res = (await _context.UserLocations
            .Include(x => x.Location)
            .ThenInclude(x => x.Images)
            .Where(x => userIds.Contains(x.UserFK) && x.DeletedOn == null)
            .ToListAsync())
            .GroupBy(x => x.UserFK)
            .ToDictionary(x => x.Key, v => v.Select(x => new LocationDto(x.LocationFK, x.Location.Name, x.Location.Images.Select(y => y.Path).ToList())));

        foreach (UserProfileDto user in users.Where(x => res.ContainsKey(x.Id)))
        {
            user.Locations = res[user.Id].ToList();
        }

        return users;
    }

    public async Task<UserProfileDto> GetUserProfileAsync([FromRoute] int userId)
    {
        UserProfileDto user = await _context.Users
            .Where(x => x.Id == userId && x.DeletedOn == null)
            .Select(x => new UserProfileDto(x.Id, x.FirstName, x.LastName, x.Email, x.ProfilePicture, new List<LocationDto>()))
            .FirstAsync();

        user.Locations = await _context.UserLocations
            .Include(x => x.Location)
            .ThenInclude(x => x.Images)
            .Where(x => x.UserFK == userId && x.DeletedOn == null)
            .Select(x => new LocationDto(x.LocationFK, x.Location.Name, x.Location.Images.Select(y => y.Path).ToList()))
            .ToListAsync();

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
