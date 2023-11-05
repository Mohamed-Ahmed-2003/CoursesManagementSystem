using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.ViewModels
{
    public class TraineeViewModel
    {
        public Trainee  trainee { get; set; }
        public IEnumerable<Course> EnrolledCourses { get; set; }
        // public List<Post> Posts{ get; set; }
        // public List<Trainee> TopPerformingStudents{ get; set; }
    }
}