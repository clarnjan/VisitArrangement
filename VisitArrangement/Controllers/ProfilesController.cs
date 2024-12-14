namespace VisitArrangement.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using VisitArrangement.API.Model.DTO;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> GetUserProfiles()
    {
        

        return Ok();
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserProfile([FromRoute]int userId)
    {


        return Ok();
    }
}
