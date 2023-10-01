using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using CoursesManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
  
    [Authorize( Roles ="Admin")]
    public class CourseController : Controller
    {
        private readonly CourseService courseService = new CourseService();
        private readonly CategoryService categoryService = new CategoryService();
        private readonly TrainerService trainerService = new TrainerService();
        // GET: Course
        public ActionResult Index(int? id)
        {
            IEnumerable<Course> courses;
            if (id == null)
                courses = courseService.ReadAll();
            else courses =courseService.GetTrainerCourses(id);
            return View(courses);
        }
      
      
        public ActionResult Create()
        {
            CourseCreateViewModel model = new CourseCreateViewModel();
               FillModelForView (ref model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CourseCreateViewModel model)
        {
            try
            {
                model.course.CreatedDate = DateTime.Now;

                model.course.ImageUrl = SaveImage(model.ImageFile);
                 

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
            var model = new CourseCreateViewModel();
            model.course = courseService.GetCourse(Id);
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
        public ActionResult Details (int Id)
        {
            var course = courseService.GetCourse(Id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }
        
        private string SaveImage (HttpPostedFileBase ImageFile ,  string OldImageUrl = null)
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
        private void FillModelForView (ref CourseCreateViewModel model)
        {
          
                model.Trainers = new SelectList(trainerService.ReadAll(), "Id", "Name");
                model.Categories = new SelectList(categoryService.ReadAll(), "Id", "Name");  
        }
        public ActionResult Search(string input)
        {
            return View("Index",courseService.SearchCourses(input));
        }


    }

}