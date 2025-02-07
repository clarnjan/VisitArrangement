namespace VisitArrangement.Domain.Model.DTO;

public class UserProfileDto
{
    public UserProfileDto(int id, string firstName, string lastName, string email, string profilePicture, double? rating, ICollection<LocationDto> locations)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ProfilePicture = profilePicture;
        Rating = rating;
        Locations = locations;
        VisitArranged = false;
        Rated = false;
        Reviews = [];
    }

    public int Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string ProfilePicture { get; set; }

    public double? Rating { get; set; }

    public ICollection<LocationDto> Locations { get; set; }

    public ICollection<ReviewDto> Reviews { get; set; }

    public bool VisitArranged { get; set; }

    public bool Rated { get; set; }
}
