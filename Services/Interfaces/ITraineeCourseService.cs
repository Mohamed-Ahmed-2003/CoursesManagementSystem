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
        IEnumerable<Trainee> ReadAll();
        IEnumerable<Trainee> GetTraineesByCourseID(int? courseID);
    }
}
