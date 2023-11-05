using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Instructor.Controllers
{
    [Authorize(Roles ="Trainer")]
    public class TraineeController : Controller
    {
            private static readonly TraineeService _traineeService = new TraineeService();
            private static readonly TraineeCourseService _traineeCourseService = new TraineeCourseService();
            public ActionResult Index(int Id)
            {
                TempData["CourseID"] = Id;
                return View(_traineeCourseService.GetTraineesByCourseID(Id));
            }
            public ActionResult EnrolledTrainess()
                {
                    var IdClaim = ClaimsPrincipal.Current.Identities.First().Claims
                           .FirstOrDefault(c => c.Type.Equals("TrainerId"));

                    return View(_traineeCourseService.GetTraineesByTrainerID(int.Parse(IdClaim.Value)));
              }

        public ActionResult UnEnroll(int tID, int? cID = null)
        {
            if (cID == null)
            {
                var tempCID = TempData["CourseID"]?.ToString();

                if (string.IsNullOrEmpty(tempCID))
                    return HttpNotFound();

                cID = int.Parse(tempCID);
            }

            _traineeCourseService.UnEnroll(tID,(int)cID);
            return RedirectToAction("Index", new { id = (int)cID }); 
        }



    }


}