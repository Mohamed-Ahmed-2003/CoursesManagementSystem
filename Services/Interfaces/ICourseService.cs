using CoursesManagementSystem.Areas.Admin.Controllers;
using CoursesManagementSystem.Controllers;
using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface ICourseService
    {
        IEnumerable<Course> ReadAll ();
        IEnumerable<Course> GetTrainerCourses(int? id);
        IEnumerable<Course> Sort(string search, SortType sortType);

        void Add (Course course);
        Course GetCourse(int id);
        bool Update (Course course);
        void Delete (int Id);

       
    }
}
