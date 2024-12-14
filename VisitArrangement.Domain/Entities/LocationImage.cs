namespace VisitArrangement.Domain.Entities;

public class LocationImage : BaseEntity
{
    public int LocationFK { get; set; }

    public Location Location { get; set; }

    public int ImageFK { get; set; }

    public Image Image { get; set; }
}
