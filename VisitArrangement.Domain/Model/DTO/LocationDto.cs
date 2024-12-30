namespace VisitArrangement.Domain.Model.DTO;

public class LocationDto
{
    public LocationDto(int id, string name, ICollection<string> images)
    {
        Id = id;
        Name = name;
        Images = images;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<string> Images { get; set; }
}
