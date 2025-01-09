namespace VisitArrangement.Domain.Services;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Context;

public class MessagesService : IMessagesService
{
    private VisitArrangementDbContext _context;

    public MessagesService(VisitArrangementDbContext context)
    {
        _context = context;
    }

    public async Task<List<MessageInfoDto>> GetUserMessagesAsync(int userId)
    {
        var groupedMessages = await _context.Messages
            .Include(x => x.SentFrom)
            .Include(x => x.SentTo)
            .Where(x => x.SentFromFK == userId || x.SentToFK == userId)
            .GroupBy(x => x.SentFromFK == userId ? x.SentToFK : x.SentFromFK)
            .Select(g => g.OrderByDescending(m => m.CreatedOn).FirstOrDefault())
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
}
