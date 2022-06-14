using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MDS_BE.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
        public virtual Register Register { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
        //public virtual ICollection<UserCourse> UserCourses { get; set; }
        //public virtual Project Project { get; set; }
    }
}