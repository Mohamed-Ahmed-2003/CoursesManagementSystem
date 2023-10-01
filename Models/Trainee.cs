using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
   
        public DateTime AddedDate { get; set; }
        bool IsActive { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}