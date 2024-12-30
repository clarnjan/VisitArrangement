namespace VisitArrangement.Infrastructure.Entities;

public class LocationImage : BaseEntity
{
    public LocationImage()
    {
    }

    public LocationImage(Location location, string path)
    {
        Location = location;
        Path = path;
    }

    public int LocationFK { get; set; }

    public Location Location { get; set; }

    public string Path { get; set; }
}
