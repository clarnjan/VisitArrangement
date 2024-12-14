namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VisitArrangement.Domain.Entities;

public class UserLocationMapping : IEntityTypeConfiguration<UserLocation>
{
    public void Configure(EntityTypeBuilder<UserLocation> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(b => b.UserFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Location)
            .WithMany()
            .HasForeignKey(b => b.LocationFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("UserLocation");
    }
}
