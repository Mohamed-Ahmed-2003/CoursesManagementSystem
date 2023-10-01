using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
       public string PhoneNumber { get; set; }
        // trainee  ,trainer  1
        public string AccountType{ get; set; }

        [Required,DataType(DataType.Password)]
       public string Password { get; set; }
        [Required,DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "The two passwords do not match")]
        [MinLength(8),MaxLength(25)]
       public string ConfirmPassword { get; set; }

    }
}