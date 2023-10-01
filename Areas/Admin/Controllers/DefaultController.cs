using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            return View();



        }
    }
}