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
    public class TrainerController : Controller
    { 
        private static readonly TrainerService _trainerService = new TrainerService();
        // GET: Admin/Trainer
        public ActionResult Index()
        {
            return View(_trainerService.ReadAll());
        }

        // GET: Admin/Trainer/Details/5
        public ActionResult Details(int id)
        {
            var trainer = _trainerService.GetTrainerById(id);
            if (trainer is null)
                return HttpNotFound();

            return View(trainer);
        }

        // GET: Admin/Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainer/Create
        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            try
            {
                trainer.AddedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    bool added = _trainerService.Add(trainer);
                    if (!added)
                        throw new Exception("This Email Already Exists");
                return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            
            return View(trainer);
            
        }

        // GET: Admin/Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            var trainer = _trainerService.GetTrainerById(id);

            if (trainer is null)
                return HttpNotFound();

            return View(trainer);
        }

        // POST: Admin/Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Trainer modifiedTrainer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_trainerService.Update(id, modifiedTrainer))
                        return RedirectToAction("Index");
                    else
                        throw new Exception("An error has occurred while updating");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
                return View(modifiedTrainer);
        }

        // GET: Admin/Trainer/Delete/5
        public ActionResult Delete(int id)
        {

            var trainer = _trainerService.GetTrainerById(id);

            if (trainer is null)
                return HttpNotFound();

            return View(trainer);
        }

        // POST: Admin/Trainer/Delete/5
        [HttpPost]
        public ActionResult ConfirmedDelete(int id)
        {
            try
            {
                _trainerService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(_trainerService.GetTrainerById(id));
            }
        }
    }
}
