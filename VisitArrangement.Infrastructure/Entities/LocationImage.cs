namespace VisitArrangement.Infrastructure.Entities;

public class LocationImage : BaseEntity
{
    public int LocationFK { get; set; }

    public Location Location { get; set; }

    public string Path { get; set; }
}
