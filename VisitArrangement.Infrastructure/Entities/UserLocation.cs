namespace VisitArrangement.Infrastructure.Entities;


public class UserLocation : BaseEntity
{
    public UserLocation(int locationFK, int userFK)
    {
        LocationFK = locationFK;
        UserFK = userFK;
    }

    public UserLocation(Location location, int userFK)
    {
        Location = location;
        UserFK = userFK;
    }

    public int LocationFK { get; set; }

    public Location Location { get; set; }

    public int UserFK { get; set; }

    public User User { get; set; }
}
