using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService = new CourseService();
        private readonly CategoryService categoryService = new CategoryService();
        // GET: Default
        public ActionResult Index()
        {
            return View(_courseService.ReadAll());

        }
        public ActionResult Details (int  id)
        {
            var course = _courseService.GetCourse(id);
            if (course == null)  return HttpNotFound();
            ViewBag.catgories = categoryService.GetParentCategoriesById(course.CategoryId);

            return View(course);
        }
        public ActionResult Enroll(int Id)
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("Login", "Account", new { returnUrl = $"/Course/Enroll/{Id}" });
            return View();
        }
        public ActionResult Search(string input)
        {
            ViewBag.Search = input;
            return View("CourseResults", _courseService.SearchCourses(input));
        }
        public ActionResult Sort(string input, SortType sortType)
        {
            
            ViewBag.Search = input;
            ViewBag.SortType = sortType.ToString();
            return View("CourseResults", _courseService.Sort(input, sortType));
        }
    }
}