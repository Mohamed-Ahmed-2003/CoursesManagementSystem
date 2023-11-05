using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService = new CourseService();
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly TraineeCourseService _traineeCourseService = new TraineeCourseService();

        // GET: Default
        public ActionResult Index()
        {
           return View(_courseService.ReadAll());

        }
        public ActionResult Details (int  id)
        {
            var IDClaim = ClaimsPrincipal.Current
           .Identities
           .First().Claims
           .FirstOrDefault(C => C.Type.Equals("TraineeID", StringComparison.OrdinalIgnoreCase));

            ViewBag.Enrolled = "";

            if (IDClaim != null) {

                if (_traineeCourseService.IsEnrolled(id, int.Parse(IDClaim.Value)))
                    ViewBag.Enrolled = "Enrolled";
            }

            var course = _courseService.GetCourse(id);
            if (course == null)  return HttpNotFound();

            ViewBag.catgories = _categoryService.GetParentCategoriesById(course.CategoryId);
            ViewBag.TraineeCourseModel = _traineeCourseService.GetTCInfoById(id)
                ;

            return View(course);
        }

        public ActionResult Enroll(int CourseId)
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("Login", "Account", new { returnUrl = $"/Course/Details/{CourseId}" });

            var IDClaim = ClaimsPrincipal.Current
                        .Identities
                        .First().Claims
                        .FirstOrDefault(C => C.Type.Equals("TraineeID", StringComparison.OrdinalIgnoreCase));

            if (IDClaim != null)
            {
                TraineeCourse model = new TraineeCourse()
                {
                    EnrolledDate = DateTime.Now,
                    TraineeID = int.Parse(IDClaim.Value),
                    CourseID = CourseId
                };

                if (ModelState.IsValid)
                {
                    _traineeCourseService.Enroll(model);
                    // UPDATE course stats
                    var course = _courseService.GetCourse(model.CourseID);
                    course.EnrolledTrainees++;
                    _courseService.Update(course);

                }
            }

            return RedirectToAction("EnrolledCourses","Trainee");
        }
        [HttpPost]
        public ActionResult Review(TraineeCourse TC)
        {
            var IDClaim = ClaimsPrincipal.Current
                .Identities
                .First().Claims
                .FirstOrDefault(C => C.Type.Equals("TraineeID", StringComparison.OrdinalIgnoreCase));

            TC.TraineeID = int.Parse(IDClaim.Value);
            TC.ReviewDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                var course = _courseService.GetCourse(TC.CourseID);

                // Check if the trainee has already submitted a review
                int? oldRating = _traineeCourseService.AddedReview(TC.CourseID, TC.TraineeID);

                if (oldRating != null)
                {
                    // Subtract the old rating before adding the new one
                    course.Rating = (double)(course.Rating * course.Reviewers - (int)oldRating + TC.Rating) / course.Reviewers;
                }
                else
                {
                    // If it's a new review, update the average rating
                    course.Rating = (double)((course.Rating * course.Reviewers) + TC.Rating) / (course.Reviewers + 1);
                    course.Reviewers++;
                }

                _traineeCourseService.AddReview(TC);

                // UPDATE course stats
                _courseService.Update(course);
            }

            return RedirectToAction("Details", new { id = TC.CourseID });
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