namespace VisitArrangement.Domain.Model.DTO;

public class UserMessagesDto
{
    public UserMessagesDto(int id, string firstName, string lastName, string profilePicture, List<MessageDetailsDto> messages)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ProfilePicture = profilePicture;
        Messages = messages;
    }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ProfilePicture { get; set; }

    public List<MessageDetailsDto> Messages { get; set; }
}
