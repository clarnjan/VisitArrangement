namespace VisitArrangement.Domain.Interfaces;

using VisitArrangement.Infrastructure.Entities;

public interface IArrangementService
{
    public Task<Arrangement> ArrangeVisitAsync(int userId, int otherUserId);
}
