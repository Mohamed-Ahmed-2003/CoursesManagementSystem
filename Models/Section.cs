using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons{ get; set; }

    }
}