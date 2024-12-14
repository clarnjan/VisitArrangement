namespace VisitArrangement.Domain.Entities;


public class UserLocation : BaseEntity
{
    public int LocationFK { get; set; }

    public Location Location { get; set; }

    public int UserFK { get; set; }

    public User User { get; set; }
}
