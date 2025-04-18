﻿namespace VisitArrangement.API.Controllers;
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

    [HttpGet("{userId:int}")]
    public async Task<List<UserProfileDto>> GetUserProfiles(
    [FromRoute] int userId,
    [FromQuery] string? search = null,
    [FromQuery] int? minRating = null)
    {
        return await ProfileService.GetUserProfilesAsync(userId, search, minRating);
    }


    [HttpGet("{userId:int}/details/{otherUserId}")]
    public async Task<UserProfileDto> GetUserProfile([FromRoute] int userId, [FromRoute]int otherUserId)
    {
        return await ProfileService.GetUserProfileAsync(userId, otherUserId);
    }

    [HttpPut("{userId:int}")]
    public async Task<IActionResult> UpdateUserProfile([FromRoute] int userId, [FromBody] UserProfileDto userProfileDto)
    {
        await ProfileService.UpdateUserProfileAsync(userId, userProfileDto);

        return Ok();
    }
}
