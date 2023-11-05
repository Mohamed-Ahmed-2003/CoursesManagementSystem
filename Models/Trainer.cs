using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public string Description { get; set; }
        public string Expertise { get; set; }
        public string SocialLinks { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<Course> courses { get; set; }

    }
}