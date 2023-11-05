using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Instructor.Controllers
{
    [Authorize(Roles = "Trainer")]

    public class LessonController : Controller
    {
        private readonly LessonService _lessonService = new LessonService();
        // GET: Lesson
        public ActionResult Index(int Id) // Lesson id 
        {
            return View(_lessonService.GetLesson(Id));
        }
        
        public ActionResult Create(int Id) 
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Create(int Id , Lesson lesson)
        {

                lesson.SectionId = Id;
            if (ModelState.IsValid)
            {
                _lessonService.Add(lesson);
                return RedirectToAction("Details","Section",new {id = lesson.SectionId});
            }
            return View(lesson);
        } 
        
        public ActionResult Edit(int Id)  //Lesson id
        {
            
            return View(_lessonService.GetLesson(Id));
        }
        [HttpPost] 
        public ActionResult Edit(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _lessonService.Update(lesson);
                return RedirectToAction("Details", "Section", new { id = lesson.SectionId });
            }
            return View(lesson);
        }
        public ActionResult Remove (int Id)
        {
            try
            {
                var lesson = _lessonService.GetLesson(Id);
                _lessonService.Remove(lesson);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the Leson. Exception: {ex}");

                return Json(new {success=false }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}

