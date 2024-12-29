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

    public async Task<List<User>> GetUserProfilesAsync()
    {
        List<User> users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task<User> GetUserProfileAsync([FromRoute] int userId)
    {
        User user = await _context.Users.Where(x => x.Id == userId).FirstAsync();

        return user;
    }

    public async Task<User> UpdateUserProfileAsync([FromRoute] int userId, [FromBody] UserProfileDto userProfileDto)
    {
        User user = await _context.Users.Where(x => x.Id == userId).FirstAsync();
        user.FirstName = userProfileDto.FirstName;
        user.LastName = userProfileDto.LastName;
        user.ProfilePicture = userProfileDto.profilePicture;
        await _context.SaveChangesAsync();

        return user;
    }
}
