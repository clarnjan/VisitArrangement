namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitArrangement.Domain.Entities;

public class MessageMapping : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Text)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.HasOne(c => c.SentFrom)
            .WithMany()
            .HasForeignKey(b => b.SentFromFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.SentTo)
            .WithMany()
            .HasForeignKey(b => b.SentToFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Message");
    }
}
