namespace VisitArrangement.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VisitArrangement.API.Model.DTO;
using VisitArrangement.Domain.Entities;
using VisitArrangement.Infrastructure.Context;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase
{
    private VisitArrangementDbContext _context;

    public ProfilesController(VisitArrangementDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    public async Task<List<User>> GetUserProfiles()
    {
        List<User> users = await _context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{userId:int}")]
    public async Task<User> GetUserProfile([FromRoute]int userId)
    {
        User user = await _context.Users.Where(x => x.Id == userId).FirstAsync();

        return user;
    }

    [HttpPut("{userId:int}")]
    public async Task<IActionResult> UpdateUserProfile([FromRoute] int userId, [FromBody] UserProfileDto userProfileDto)
    {
        User user = await _context.Users.Where(x => x.Id == userId).FirstAsync();
        user.FirstName = userProfileDto.FirstName;
        user.LastName = userProfileDto.LastName;
        user.ProfilePicture = userProfileDto.profilePicture;
        await _context.SaveChangesAsync();

        return Ok();
    }
}
