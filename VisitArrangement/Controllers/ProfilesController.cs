namespace VisitArrangement.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Entities;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase
{
    private IProfileService ProfileService;

    public ProfilesController(IProfileService profileService)
    {
        ProfileService = profileService;
    }

    [HttpGet()]
    public async Task<List<UserProfileDto>> GetUserProfiles()
    {
        return await ProfileService.GetUserProfilesAsync();
    }

    [HttpGet("{userId:int}")]
    public async Task<UserProfileDto> GetUserProfile([FromRoute]int userId)
    {
        return await ProfileService.GetUserProfileAsync(userId);
    }

    [HttpPut("{userId:int}")]
    public async Task<IActionResult> UpdateUserProfile([FromRoute] int userId, [FromBody] UserProfileDto userProfileDto)
    {
        await ProfileService.UpdateUserProfileAsync(userId, userProfileDto);

        return Ok();
    }
}
