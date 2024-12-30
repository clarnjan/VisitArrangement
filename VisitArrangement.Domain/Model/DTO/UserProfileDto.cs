namespace VisitArrangement.Domain.Model.DTO;

public class UserProfileDto
{
    public UserProfileDto(int id, string firstName, string lastName, string email, string profilePicture, ICollection<LocationDto> locations)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ProfilePicture = profilePicture;
        Locations = locations;
    }

    public int Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string ProfilePicture { get; set; }

    public ICollection<LocationDto> Locations { get; set; }
}
