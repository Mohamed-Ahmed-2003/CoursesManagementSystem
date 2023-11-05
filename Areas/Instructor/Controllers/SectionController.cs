using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web;

namespace CoursesManagementSystem.Areas.Instructor.Controllers
{
    [Authorize(Roles = "Trainer")]
    public class SectionController : Controller
    {
        private readonly SectionService _sectionService = new SectionService();

        public ActionResult Index(int? Id)
        {
            if (Id == null) return HttpNotFound();
            ViewBag.CourseId = Id;
            return View(_sectionService.ReadAll(Id));
        }

        

        [HttpPost]
        public ActionResult Create(int Id, string sectionName)
        {
            var section = new Section()
            {
                CourseId = Id,
                Name = sectionName
            };


            if (ModelState.IsValid)

            {
                _sectionService.Add(section);
                return Json(new { sectionName = section.Name });
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid ModelState");
        }

      
        public ActionResult Remove(int id)
        {
            var section = _sectionService.GetSectionById(id);
            try
            {
                if (section != null)
                {
                    _sectionService.Remove(section);
                }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult Edit(int id)
        {
            var section = _sectionService.GetSectionById(id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        [HttpPost]
        public ActionResult Edit(Section modifiedSection)
        {
            if (ModelState.IsValid)
            {
                _sectionService.Update(modifiedSection);
                return RedirectToAction("Index", new { Id = modifiedSection.Id });
            }

            return View(modifiedSection);
        }
        public ActionResult Details (int id)
        {
            
            return View (_sectionService.GetSectionById(id));
        }
    }

}