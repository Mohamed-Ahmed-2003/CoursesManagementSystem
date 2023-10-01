using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Areas.Instructor.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Instructor/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}