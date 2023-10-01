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
    public class CategoryController : Controller
    {
        public static CategoryService categoryService = new CategoryService();
        public ActionResult Index()
        {
            var categories = categoryService.ReadAll();
            return View(categories);
        }
        public ActionResult Create()
        {
            var mainCategoriesList = categoryService.ReadAll();

            mainCategoriesList.Insert(0, null);

            ViewBag.MainCategories = new SelectList(mainCategoriesList, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View();

            bool succed = categoryService.Add(category);
            if (succed)
            return RedirectToAction("Index");

            var mainCategoriesList = categoryService.ReadAll();

            mainCategoriesList.Insert(0, null);

            ViewBag.MainCategories = new SelectList(mainCategoriesList, "Id", "Name");

            ViewBag.Message = "This Category Name already exists";
            return View(category);
        }

        public ActionResult Edit (int id)
        {
            var category = categoryService.GetCategory(id);

            if (category == null)
            {
                return View("Index");
            }
            var mainCategoriesList = categoryService.ReadAll().Where(c=>c.Id != id).ToList();

            mainCategoriesList.Insert(0, null);

            ViewBag.MainCategories = new SelectList(mainCategoriesList, "Id", "Name");


            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
             bool succes = categoryService.Update(category);
             if (!succes)
                {
                    ViewBag.Message = "This Category Name already exists";
                    var mainCategoriesList = categoryService.ReadAll().Where(c => c.Id != category.Id).ToList();

                    mainCategoriesList.Insert(0, null);

                    ViewBag.MainCategories = new SelectList(mainCategoriesList, "Id", "Name");
                    return View(category);
                }    
            }
            return RedirectToAction("Index");
        } 
        
        public ActionResult Delete (int id)
        {
            return View(categoryService.GetCategory(id));
        }
        public ActionResult DeleteConfirmed(int id)
        {

            categoryService.Delete(id);

            return RedirectToAction("Index");
        }


    }
}