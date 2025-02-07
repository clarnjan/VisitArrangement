namespace VisitArrangement.Domain.Model.DTO;

public class ReviewDto
{
    public ReviewDto(string firstName, string lastName, string profilePicture, int rating, string? comment)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfilePicture = profilePicture;
        Rating = rating;
        Comment = comment;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePicture { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
