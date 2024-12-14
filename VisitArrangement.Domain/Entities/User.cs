using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitArrangement.Domain.Entities
{
    public class User : IdentityUser
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
