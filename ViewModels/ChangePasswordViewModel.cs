using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Current Password")]
        [MinLength(8, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(25, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [MaxLength(25, ErrorMessage = "The {0} must not exceed {1} characters.")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The New Password and Confirm New Password must match.")]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }

}