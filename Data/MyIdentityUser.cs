using CoursesManagementSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Data
{
    public class MyIdentityUser : IdentityUser
    {
        // Foreign keys
        public int? TraineeID { get; set; }

        public int? TrainerID { get; set; }

        public int? AdminID { get; set; }

        // Navigation properties
        [ForeignKey("TraineeID")]
        public Trainee Trainee { get; set; }
        [ForeignKey("TrainerID")]
        public Trainer Trainer { get; set; }
        [ForeignKey("AdminID")]
        public Admin Admin { get; set; }
    }

}