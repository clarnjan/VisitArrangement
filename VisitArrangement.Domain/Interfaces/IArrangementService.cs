namespace VisitArrangement.Domain.Interfaces;

using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Entities;

public interface IArrangementService
{
    public Task<Arrangement> ArrangeVisitAsync(int userId, int otherUserId);

    public Task<Review> ReviewUserAsync(int userId, int otherUserId, ReviewRequest reviewRequest);
}
