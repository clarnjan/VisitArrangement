namespace VisitArrangement.Domain.Entities;

public class Review : BaseEntity
{
    public int ByUserFK { get; set; }

    public User ByUser { get; set; }

    public int ForUserFK { get; set; }

    public User ForUser { get; set; }

    public int ArrangementFK { get; set; }

    public Arrangement Arrangement { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; }
}
