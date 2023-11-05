using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Models
{
    public class TraineeCourse
    {
        [Key,Column(Order =0)]
        public int TraineeID { get; set; }
        [Key,Column(Order = 1)]
        public int CourseID { get; set; }
        public DateTime EnrolledDate { get; set; }

        public int? Rating { get; set; }
        public string ReviewTitle {get; set; }
        public DateTime? ReviewDate{get; set; }
        public  string Review { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        [ForeignKey("TraineeID")]
        public virtual Trainee Trainee { get; set; }
    }
}