using CoursesManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly TrainerService trainerService = new TrainerService();
        public ActionResult TrainerDetails (/*int Id*/) // trainer
        {
            //var trainer = trainerService.GetTrainerById (Id);
            //if (trainer == null)
            //    return HttpNotFound();

            return View(/*trainer*/);
        }
    }
}