namespace VisitArrangement.Domain.Model.DTO;

public class MessageDetailsDto
{
    public MessageDetailsDto(string messageText, bool isSentByCurrentUser, DateTime sentOn)
    {
        MessageText = messageText;
        IsSentByCurrentUser = isSentByCurrentUser;
        SentOn = sentOn;
    }

    public string MessageText { get; set; }

    public bool IsSentByCurrentUser  { get; set; }

    public DateTime SentOn { get; set; }
}
