using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Controllers
{

    public class TraineeController : Controller
    {
        private readonly TraineeService _traineeService = new TraineeService();
        private readonly TraineeCourseService _traineeCourseService = new TraineeCourseService();


        public ActionResult Details(int id)
        {
            var model = new TraineeViewModel()
            {
                trainee = _traineeService.GetTraineeById(id),
                EnrolledCourses = _traineeCourseService.GetCoursesByTraineeID(id)
            };
            return View(model);
        }
            public ActionResult EnrolledCourses ()
        {
            var IDClaim = ClaimsPrincipal.Current
                .Identities
                .First().Claims
                .FirstOrDefault(C => C.Type.Equals("TraineeID", StringComparison.OrdinalIgnoreCase));

            var courses = _traineeCourseService.GetCoursesByTraineeID(int.Parse(IDClaim.Value));
            return View(courses);
        }

     
    }
}