using CoursesManagementSystem.Areas.Admin.Models;
using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using CoursesManagementSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private TraineeService traineeService = new TraineeService();
    public AccountController()
        {
            var userStore = new UserStore<MyIdentityUser>(new MyAppContext());

            userManager = new UserManager<MyIdentityUser>(userStore);

        }

        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string ReturnUrl, ViewModels.LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindAsync(model.EmailAddress,model.Password);
                if (user != null)
                {
                    await SignIn(user);
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    var role = userManager.GetRoles(user.Id).FirstOrDefault();
                    if (role == "Admin")
                        return RedirectToAction("Index", "Course", new { area = "Admin" });
                    else if (role == "Trainee")
                        return RedirectToAction("Index", "Course");
                }
            }
            model.Message = "Email-Address or password is incorrect";
            return View(model);
        }
        public ActionResult Logout() {

            var owinContext = Request.GetOwinContext();
            var authManager = owinContext.Authentication;
            authManager.SignOut("ApplicationCookie");
            Session.Abandon();  
            return RedirectToAction("Login","Account",new {area = ""});

        }
        private async Task SignIn (MyIdentityUser user)
        {
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            var owinContext = Request.GetOwinContext();
            var authManager = owinContext.Authentication;
            authManager.SignIn(identity);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyIdentityUser()
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                IdentityResult creationState = await userManager.CreateAsync(user, model.Password);
                if (creationState.Succeeded)
                {

                    userManager.AddToRole(user.Id, model.AccountType);

                    if (model.AccountType == "Trainee")
                    {
                        traineeService.Add(new Trainee { AddedDate = DateTime.Now, Email = model.Email, Name = model.Name });
                    }

                    return RedirectToAction("Index", "Course");
                }
            else
            {
                foreach (var error in creationState.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            }
            return View(model);
        }

    }
}