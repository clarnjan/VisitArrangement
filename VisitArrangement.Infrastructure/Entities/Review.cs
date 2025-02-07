namespace VisitArrangement.Infrastructure.Entities;

using System.Text.Json.Serialization;

public class Review : BaseEntity
{
    public Review(int byUserFK, int forUserFK, int arrangementFK, int rating, string? comment)
    {
        ByUserFK = byUserFK;
        ForUserFK = forUserFK;
        ArrangementFK = arrangementFK;
        Rating = rating;
        Comment = comment;
    }

    public int ByUserFK { get; set; }

    public User ByUser { get; set; }

    public int ForUserFK { get; set; }

    public User ForUser { get; set; }

    public int ArrangementFK { get; set; }

    [JsonIgnore]
    public Arrangement Arrangement { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }
}
