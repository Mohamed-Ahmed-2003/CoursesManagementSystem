using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class TraineeCourseController : Controller
    {
        private TraineeCourseService _service = new TraineeCourseService();
        // GET: Admin/TraineesCourse
        public ActionResult TraineeCourses(int id)
        {
            return View(_service.GetCoursesByTraineeID(id));
        } 
        
   
        public ActionResult TraineesCourse(int? id )
        {
            IEnumerable<Trainee> trainees;

            if (id != null)
            {
                trainees = _service.GetTraineesByCourseID(id);
                ViewBag.Header = $"Course with Id {id} Trainees";
            }

            else
            {
                trainees = _service.ReadAll();

                ViewBag.Header = $"Courses Trainees";

            }
            if (!trainees.Any()) ViewBag.Error = $"There Are No Trainees yet";
            return View(trainees);
        }


    }
}