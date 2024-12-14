namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitArrangement.Domain.Entities;

public class ImageMapping : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Path)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.ToTable("Image");
    }
}
