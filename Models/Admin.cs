using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name{ get; set;}
        [Required]
        [EmailAddress]
        public string Email{ get; set;}
     
    }
}