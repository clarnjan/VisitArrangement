namespace VisitArrangement.Domain.Services;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Model.DTO;
using VisitArrangement.Infrastructure.Context;
using VisitArrangement.Infrastructure.Entities;

public class ArrangementService : IArrangementService
{
    private VisitArrangementDbContext _context;

    public ArrangementService(VisitArrangementDbContext context)
    {
        _context = context;
    }

    public async Task<Arrangement> ArrangeVisitAsync(int userId, int otherUserId)
    {
        Arrangement? arrangement = await _context.Arrangements
            .FirstOrDefaultAsync(x => (x.HostFK == userId && x.VisitorFK == otherUserId) || (x.HostFK == otherUserId && x.VisitorFK == userId));


        if (arrangement != null)
        {
            if (arrangement.HostFK == userId)
            {
                arrangement.ApprovedByHost = true;
            }
            else
            {
                arrangement.ApprovedByVisitor = true;
            }
        }
        else
        {
            arrangement = new Arrangement
            {
                HostFK = userId,
                VisitorFK = otherUserId,
                ApprovedByHost = true,
                ApprovedByVisitor = false
            };
            _context.Arrangements.Add(arrangement);
        }

        await _context.SaveChangesAsync();

        return arrangement;

    }

    public async Task<Review> ReviewUserAsync(int userId, int otherUserId, ReviewRequest reviewRequest)
    {
        Arrangement? arrangement = await _context.Arrangements
            .FirstOrDefaultAsync(x => (x.HostFK == userId && x.VisitorFK == otherUserId) || (x.HostFK == otherUserId && x.VisitorFK == userId));
        if (arrangement == null)
        {
            throw new Exception("Arrangement not found");
        }
        Review review = new Review(userId, otherUserId, arrangement.Id, reviewRequest.Rating, reviewRequest.Comment);

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }
}
