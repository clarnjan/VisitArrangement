namespace VisitArrangement.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Domain.Services;
using VisitArrangement.Infrastructure.Entities;

[Route("api/[controller]")]
[ApiController]
public class ArrangementController : ControllerBase
{
    IArrangementService ArrangementService;

    public ArrangementController(IArrangementService arrangementService)
    {
        ArrangementService = arrangementService;
    }

    [HttpPost("{userId:int}/arrange/{otherUserId}")]
    public async Task<Arrangement> ArrangeVisitAsync([FromRoute] int userId, [FromRoute] int otherUserId)
    {
        return await ArrangementService.ArrangeVisitAsync(userId, otherUserId);
    }
}
