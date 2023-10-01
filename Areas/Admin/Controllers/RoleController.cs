using CoursesManagementSystem.Data;
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
    public class RoleController : Controller
    {

        private MyAppContext context;
        public RoleController()
        {
            context = new MyAppContext();
        }
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();

            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string roleName)
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

    }
}