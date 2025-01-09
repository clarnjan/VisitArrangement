namespace VisitArrangement.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private IMessagesService MessagesService;

    public MessagesController(IMessagesService messagesService)
    {
        MessagesService = messagesService;
    }

    [HttpGet("{userId:int}")]
    public async Task<List<MessageInfoDto>> GetUserProfile([FromRoute] int userId)
    {
        return await MessagesService.GetUserMessagesAsync(userId);
    }
}
