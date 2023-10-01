using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.ViewModels
{
    public class TraineeCourseViewModel
    {
        public Trainee trainee {  get; set; }
        public DateTime EnrolledDate { get; set; }
        public int CourseID { get; set; }

    }
}