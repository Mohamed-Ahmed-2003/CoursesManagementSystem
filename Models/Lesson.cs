using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int  SectionId { get; set; }
        [Required]
        public double Duration { get; set; }
        public int  OrderNumber { get; set; }
        [ForeignKey("SectionId")]
        public virtual Section section{ get; set; }

    }
}