using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
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
                return RedirectToAction("Index","Section",new {id = lesson.SectionId});
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
                return RedirectToAction("Index", "Section", new { id = lesson.SectionId });
            }
            return View(lesson);
        }
        public ActionResult Delete (int Id)
        {
            return View(_lessonService.GetLesson(Id));
        }


    }
}