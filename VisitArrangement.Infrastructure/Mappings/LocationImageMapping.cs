namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VisitArrangement.Infrastructure.Entities;

public class LocationImageMapping : IEntityTypeConfiguration<LocationImage>
{
    public void Configure(EntityTypeBuilder<LocationImage> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Path)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.ToTable("LocationImage");
    }
}
