using Microsoft.AspNetCore.Identity;

namespace VisitArrangement.Infrastructure.Entities
{
    public class User : IdentityUser
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture {  get; set; }
    }
}
