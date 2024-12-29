namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VisitArrangement.Infrastructure.Entities;

public class ArrangementMapping : IEntityTypeConfiguration<Arrangement>
{
    public void Configure(EntityTypeBuilder<Arrangement> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.ApprovedByVisitor)
            .IsRequired()
            .HasColumnType("bit");
        builder.Property(c => c.ApprovedByHost)
            .IsRequired()
            .HasColumnType("bit");

        builder.HasOne(c => c.Visitor)
            .WithMany()
            .HasForeignKey(b => b.VisitorFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Host)
            .WithMany()
            .HasForeignKey(b => b.HostFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Arrangement");
    }
}
