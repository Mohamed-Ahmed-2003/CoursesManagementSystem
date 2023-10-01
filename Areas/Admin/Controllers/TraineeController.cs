using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]

    public class TraineeController : Controller
    {
            private static readonly TraineeService _traineeService = new TraineeService();
            // GET: Admin/Trainee
            public ActionResult Index()
            {
                return View(_traineeService.ReadAll());
            }

            // GET: Admin/Trainee/Details/5
            public ActionResult Details(int id)
            {
                var trainee= _traineeService.GetTraineeById(id);
                if (trainee is null)
                    return HttpNotFound();

                return View(trainee);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(Trainee trainee)
            {
                try
                {
                    trainee.AddedDate = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        bool added = _traineeService.Add(trainee);
                        if (!added)
                            throw new Exception("This Email Already Exists");
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }

                return View(trainee);

            }

            public ActionResult Edit(int id)
            {
                var trainee = _traineeService.GetTraineeById(id);

                if (trainee is null)
                    return HttpNotFound();

                return View(trainee);
            }

            [HttpPost]
            public ActionResult Edit(int id, Trainee modifiedTrainee)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (_traineeService.Update(id, modifiedTrainee))
                            return RedirectToAction("Index");
                        else
                            throw new Exception("An error has occurred while updating");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
                return View(modifiedTrainee);
            }

            // GET: Admin/Trainee/Delete/5
            public ActionResult Delete(int id)
            {

                var trainee = _traineeService.GetTraineeById(id);

                if (trainee is null)
                    return HttpNotFound();

                return View(trainee);
            }

            // POST: Admin/Trainee/Delete/5
            [HttpPost]
            public ActionResult ConfirmedDelete(int id)
            {
                try
                {
                    _traineeService.Delete(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(_traineeService.GetTraineeById(id));
                }
            }
        }

    
}