namespace VisitArrangement.Domain.Model.DTO;

public class MessageInfoDto
{
    public MessageInfoDto(
        int userId,
        string userFirstName,
        string userLastName,
        string userProfilePicture,
        bool isSentByCurrentUser,
        string messageText)
    {
        UserId = userId;
        UserFirstName = userFirstName;
        UserLastName = userLastName;
        UserProfilePicture = userProfilePicture;
        IsSentByCurrentUser = isSentByCurrentUser;
        MessageText = messageText;
    }

    public int UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserProfilePicture{ get; set; }
    public bool IsSentByCurrentUser { get; set; }
    public string MessageText { get; set; }   
}
