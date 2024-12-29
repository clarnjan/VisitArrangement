namespace VisitArrangement.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VisitArrangement.Infrastructure.Entities;

public class LocationMapping : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.ToTable("Location");
    }
}
