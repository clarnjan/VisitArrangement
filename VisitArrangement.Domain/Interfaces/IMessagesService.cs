namespace VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Entities;

public interface IMessagesService
{
    public Task<List<MessageInfoDto>> GetMessageInfosAsync(int userId);
    public Task<UserMessagesDto> GetMessageDetailsAsync(int userId, int otherUserId);
    public Task<MessageDetailsDto> SendMessageAsync(int fromUserId, int toUserId, string messageText);
}
