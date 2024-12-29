namespace VisitArrangement.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;
using VisitArrangement.Infrastructure.Entities;
using VisitArrangement.Domain.Model.DTO;

public interface IProfileService
{
    public Task<List<User>> GetUserProfilesAsync();

    public Task<User> GetUserProfileAsync([FromRoute] int userId);

    public Task<User> UpdateUserProfileAsync([FromRoute] int userId, [FromBody] UserProfileDto userProfileDto);
}
