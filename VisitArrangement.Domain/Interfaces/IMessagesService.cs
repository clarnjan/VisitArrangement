namespace VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;

public interface IMessagesService
{
    public Task<List<MessageInfoDto>> GetUserMessagesAsync(int userId);
}
