using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.ViewModels
{
    public class IdentityUpdateViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public ChangePasswordViewModel ChangePassword { get; set; }
    }
}