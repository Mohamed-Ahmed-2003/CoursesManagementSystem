using CoursesManagementSystem.Data;
using CoursesManagementSystem.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private MyAppContext context;
        public AdminController()
        {
            context = new MyAppContext();
        }
        public ActionResult Index()
        {
            List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> roles = context.Roles.ToList();

            return View(roles);
        }
        
        public ActionResult CreateRoles()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRoles(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                ModelState.AddModelError("", "Role Name is required.");
                return View();
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole(roleName);
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Role creation failed.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Role already exists.");
            }
            return View();
        }

        public ActionResult PopulateDB()
        {
            if (!context.Categories.Any() && !context.Trainers.Any()) { 
            Initializer.PopulateDB();
            }
            return RedirectToAction("Index","Course",new {area = "Admin"});
        }

    }
}