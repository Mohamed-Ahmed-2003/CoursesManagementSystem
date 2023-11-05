using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {
        private readonly SectionService _sectionService = new SectionService();

        // GET: Admin/Section
        public ActionResult Index(int? Id)
        {
            if (Id == null) return HttpNotFound();
            ViewBag.CourseId = Id;
            return View(_sectionService.ReadAll(Id));
        }

        // GET: Admin/Section/Add
        public ActionResult Create(int Id)
        {
            return View();
        }

        // POST: Admin/Section/Add
        [HttpPost]
        public ActionResult Create(int Id,Section section)
        {
            section.CourseId = Id;

            if (ModelState.IsValid)
            {
                _sectionService.Add(section);
                return RedirectToAction("Index", new { Id = section.Id });
            }

            return View(section);
        }

        // GET: Admin/Section/Remove/5
        public ActionResult Delete(int id)
        {
            var section = _sectionService.GetSectionById(id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        // POST: Admin/Section/Remove/5
        [HttpPost, ActionName("Delete")]
        public ActionResult RemoveConfirmed(int id)
        {
            var section = _sectionService.GetSectionById(id);

            if (section != null)
            {
                _sectionService.Remove(section);
            }

            return RedirectToAction("Details","Course",new { Id = section.CourseId});
        }

        // GET: Admin/Section/Update/5
        public ActionResult Edit(int id)
        {
            var section = _sectionService.GetSectionById(id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        // POST: Admin/Section/Update/5
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