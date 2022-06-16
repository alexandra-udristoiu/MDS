using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MDS_BE.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}

