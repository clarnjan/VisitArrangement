namespace VisitArrangement.API.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<List<MessageInfoDto>> GetMessageInfosAsync([FromRoute] int userId)
    {
        return await MessagesService.GetMessageInfosAsync(userId);
    }

    [HttpGet("{userId:int}/details/{otherUserId}")]
    public async Task<UserMessagesDto> GetMessageDetailsAsync([FromRoute] int userId, [FromRoute] int otherUserId)
    {
        return await MessagesService.GetMessageDetailsAsync(userId, otherUserId);
    }

    [HttpPost("{userId:int}/details/{otherUserId}")]
    public async Task<MessageDetailsDto> SendMessageAsync([FromRoute] int userId, [FromRoute] int otherUserId, [FromBody] string messageText)
    {
        return await MessagesService.SendMessageAsync(userId, otherUserId, messageText);
    }
}
