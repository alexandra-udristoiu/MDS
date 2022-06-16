using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Entities
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /*public int AssignmentId { get; set; }*/
        public int AssignmentId { get; set; }
        public string CourseName { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
