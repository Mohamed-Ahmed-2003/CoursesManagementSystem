using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services.Interfaces;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

namespace CoursesManagementSystem.Areas.Instructor.Controllers
{
    [Authorize(Roles = "Trainer")]
    public class CourseController : Controller
    {
        private readonly CourseService courseService = new CourseService();
        private readonly CategoryService categoryService = new CategoryService();
        private readonly TrainerService trainerService = new TrainerService();
        // GET: trainer/Courses
        public ActionResult Index()
        {
            var currID = ClaimsPrincipal.Current.Identities.First().Claims.FirstOrDefault(c => c.Type.Equals("TrainerId"));


            var courses = courseService.GetTrainerCourses(int.Parse(currID.Value));
            return View(courses);
        }


        public ActionResult Create()
        {
            CourseCreateViewModel model = new CourseCreateViewModel();
            FillModelForView(ref model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CourseCreateViewModel model)
        {
            var currID = ClaimsPrincipal.Current.Identities.First().Claims.FirstOrDefault(c => c.Type.Equals("TrainerId"));

            try
            {
                model.course.CreatedDate = DateTime.Now;

                model.course.ImageUrl = SaveImage(model.ImageFile);
                model.course.TrainerId = int.Parse(currID.Value);

                if (ModelState.IsValid)
                {
                    courseService.Add(model.course);
                    return RedirectToAction("Index");
                }

            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            FillModelForView(ref model);
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = new CourseCreateViewModel
            {
                course = courseService.GetCourse(Id)
            };
            if (model.course is null)
                return HttpNotFound();

            FillModelForView(ref model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CourseCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Handle file upload
                    if (model.ImageFile != null)
                    {
                        model.course.ImageUrl = SaveImage(model.ImageFile, model.course.ImageUrl);
                    }

                    // Update the course in the database

                    if (courseService.Update(model.course))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Course not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while updating the course: " + ex.Message;
            }

            FillModelForView(ref model);
            return View(model);
        }
        public ActionResult Details(int Id)
        {
            var course = courseService.GetCourse(Id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }
        [HttpGet]
        public JsonResult Remove(int Id)
        {
            try
            {
                courseService.Delete(Id);

                return Json(new { success = true },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred while deleting the course. Exception: {ex}");

                // Return a JSON result indicating failure with a message
                return Json(new { success = false, message = "An error occurred while deleting the course." }, JsonRequestBehavior.AllowGet);
            }
        }



        private string SaveImage(HttpPostedFileBase ImageFile, string OldImageUrl = null)
        {

            var FileExtention = Path.GetExtension(ImageFile.FileName);
            var UniqueImageName = Guid.NewGuid().ToString();
            var ImageUrl = UniqueImageName + FileExtention;

            ImageFile.SaveAs(Server.MapPath($"~/Uploads/Courses/{ImageUrl}"));

            if (!String.IsNullOrEmpty(OldImageUrl))
            {
                var oldImagePath = Server.MapPath($"~/Uploads/Courses/{OldImageUrl}");
                System.IO.File.Delete(oldImagePath);
            }

            return ImageUrl;
        }
        private void FillModelForView(ref CourseCreateViewModel model)
        {

            model.Trainers = new SelectList(trainerService.ReadAll(), "Id", "Name");
            model.Categories = new SelectList(categoryService.ReadAll(), "Id", "Name");
        }
     
    }
}