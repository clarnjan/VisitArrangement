namespace VisitArrangement.Domain.Entities;

public class Arrangement : BaseEntity
{
    public int VisitorFK { get; set; }

    public User Visitor { get; set; }

    public int HostFK { get; set; }

    public User Host { get; set; }

    public bool ApprovedByVisitor { get; set; }

    public bool ApprovedByHost { get; set; }

}
