namespace VisitArrangement.Infrastructure.Entities;

public class Message : BaseEntity
{
    public Message()
    {
    }

    public Message(int sentFromFK, int sentToFK, string text)
    {
        SentFromFK = sentFromFK;
        SentToFK = sentToFK;
        Text = text;
    }

    public int SentFromFK { get; set; }

    public int SentToFK { get; set; }

    public string Text { get; set; }

    public virtual User SentFrom { get; set; }

    public virtual User SentTo { get; set; }
}
