namespace VisitArrangement.Domain.Services;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Context;
using VisitArrangement.Infrastructure.Entities;

public class MessagesService : IMessagesService
{
    private VisitArrangementDbContext _context;

    public MessagesService(VisitArrangementDbContext context)
    {
        _context = context;
    }

    public async Task<List<MessageInfoDto>> GetMessageInfosAsync(int userId)
    {
        var groupedMessages = await _context.Messages
            .Include(x => x.SentFrom)
            .Include(x => x.SentTo)
            .Where(x => x.SentFromFK == userId || x.SentToFK == userId)
            .GroupBy(x => x.SentFromFK == userId ? x.SentToFK : x.SentFromFK)
            .Select(g => g.OrderByDescending(m => m.Id).FirstOrDefault())
            .ToListAsync(); // Fetch grouped data into memory

        // Perform the projection in memory
        var latestMessagesWithUserInfo = groupedMessages
            .Select(x => new MessageInfoDto(
                x.SentFromFK == userId ? x.SentTo.Id : x.SentFrom.Id,
                x.SentFromFK == userId ? x.SentTo.FirstName : x.SentFrom.FirstName,
                x.SentFromFK == userId ? x.SentTo.LastName : x.SentFrom.LastName,
                x.SentFromFK == userId ? x.SentTo.ProfilePicture : x.SentFrom.ProfilePicture,
                x.SentFromFK == userId, // Boolean indicating if the current user is the sender
                x.Text
            ))
            .ToList();

        return latestMessagesWithUserInfo;
    }

    public async Task<UserMessagesDto> GetMessageDetailsAsync(int userId, int otherUser)
    {
        UserMessagesDto userMessages = await _context.Users
            .Where(x => x.Id == otherUser)
            .Select(x => new UserMessagesDto(x.Id, x.FirstName, x.LastName, x.ProfilePicture, new List<MessageDetailsDto>()))
            .FirstAsync();

        List<MessageDetailsDto> messages = await _context.Messages
            .Where(x => (x.SentFromFK == userId && x.SentToFK == otherUser) || (x.SentToFK == userId && x.SentFromFK == otherUser))
            .Select(x => new MessageDetailsDto(x.Text, x.SentFromFK == userId, x.CreatedOn))
            .ToListAsync();

        userMessages.Messages = messages;

        return userMessages;
    }

    public async Task<MessageDetailsDto> SendMessageAsync(int fromUserId, int toUserId, string messageText)
    {
        Message message = new Message(fromUserId, toUserId, messageText);
        message.CreatedOn = DateTime.Now;

        _context.Messages.Add(message);

        await _context.SaveChangesAsync();

        MessageDetailsDto messageDetailsDto = new MessageDetailsDto(messageText, true, message.CreatedOn);
        return messageDetailsDto;
    }
}
