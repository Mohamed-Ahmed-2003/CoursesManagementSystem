using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.ViewModels
{
    public class CourseCreateViewModel
    {
        public Course course {  get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public SelectList Trainers { get; set; }
        public SelectList Categories { get; set; }

    }
}