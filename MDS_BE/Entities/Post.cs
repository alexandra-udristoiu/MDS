using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDS_BE.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string[] Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}