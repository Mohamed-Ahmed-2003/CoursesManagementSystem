using CoursesManagementSystem.Areas.Admin.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }  
        
   
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            AdminService adminService = new AdminService();
            if (!adminService.Login(model.EmailAddress, model.Password))
            {
                model.Message = "Email Address or Password is not correct";
                return View(model);
            }

            return RedirectToAction("Index","Course");
        }

      
   

    }
}