namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VisitArrangement.Domain.Entities;

public class LocationImageMapping : IEntityTypeConfiguration<LocationImage>
{
    public void Configure(EntityTypeBuilder<LocationImage> builder)
    {
        builder.HasKey(c => c.Id);

        builder.ToTable("LocationImage");
    }
}
