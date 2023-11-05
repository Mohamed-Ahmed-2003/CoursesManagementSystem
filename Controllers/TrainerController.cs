using CoursesManagementSystem.Services;
using CoursesManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Controllers
{
    public class TrainerController : Controller
    {
        private readonly TrainerService trainerService = new TrainerService();
        public ActionResult TrainerDetails (int Id)
        {
            TrainerViewModel model = new TrainerViewModel
            {
                trainer = trainerService.GetTrainerById(Id)
            };

            (ViewBag.TraineesCount , ViewBag.Reviews ) = trainerService.TrainerStats(Id);
            if (model.trainer == null)
                return HttpNotFound();

            return View(model);
        }
    }
}