using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDS_BE.Entities
{
    public class Register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual ICollection<User> User { get; set; }

    }
}
