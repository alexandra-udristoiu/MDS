using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Entities
{
    public class UserCourse
    {
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
