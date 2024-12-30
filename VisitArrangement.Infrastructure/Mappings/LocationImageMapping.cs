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

        builder.HasOne(c => c.Location)
            .WithMany(x => x.Images)
            .HasForeignKey(b => b.LocationFK)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("LocationImage");
    }
}
