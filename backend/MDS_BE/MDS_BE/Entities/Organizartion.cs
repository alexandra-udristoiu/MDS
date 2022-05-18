using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDS_BE.Entities
{
    public class Organization
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UniversityName { get; set; }
        [Required]
        public string FacultyName { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
    }
}