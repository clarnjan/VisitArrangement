namespace VisitArrangement.Infrastructure.Entities;


public class Location : BaseEntity
{
    public Location(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public virtual ICollection<LocationImage> Images { get; set; }
}
