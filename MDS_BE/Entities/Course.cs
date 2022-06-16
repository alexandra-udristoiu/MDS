using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Entities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /* public int CourseId { get; set; }*/
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
