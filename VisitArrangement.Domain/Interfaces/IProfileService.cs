namespace VisitArrangement.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Entities;

public interface IProfileService
{
    public Task<List<UserProfileDto>> GetUserProfilesAsync(int userId);

    public Task<UserProfileDto> GetUserProfileAsync([FromRoute] int userId);

    public Task<User> UpdateUserProfileAsync([FromRoute] int userId, [FromBody] UserProfileDto userProfileDto);
}
