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

        builder.ToTable("Message");
    }
}
