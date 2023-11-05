using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface ITraineeCourseService
    {
        bool Enroll(TraineeCourse model);
        IEnumerable<Trainee> ReadAll();
        IEnumerable<Trainee> GetTraineesByCourseID(int? courseID);
        IEnumerable<Course> GetCoursesByTraineeID(int? traineeID);
        bool IsEnrolled(int courseID, int traineeID);
        void AddReview (TraineeCourse TC);
        IEnumerable<TraineeCourse> GetTCInfoById(int courseID);

    }
}
