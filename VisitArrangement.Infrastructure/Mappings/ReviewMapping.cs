namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VisitArrangement.Infrastructure.Entities;

public class ReviewMapping : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Comment)
            .IsRequired(false)
            .HasColumnType("varchar(500)");
        builder.Property(c => c.Rating)
            .IsRequired()
            .HasColumnType("tinyInt");

        builder.HasOne(c => c.ForUser)
            .WithMany(u => u.Reviews)
            .HasForeignKey(b => b.ForUserFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.ByUser)
            .WithMany()
            .HasForeignKey(b => b.ByUserFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Arrangement)
            .WithMany(a => a.Reviews)
            .HasForeignKey(b => b.ArrangementFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Review");
    }
}
