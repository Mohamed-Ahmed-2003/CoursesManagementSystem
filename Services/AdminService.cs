using CoursesManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Services.Interfaces
{
    public class AdminService : IAdminService
    {
        public static MyAppContext context = new MyAppContext();
        public AdminService() { 
       }

        public bool ChangePassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string Email)
        {
            throw new NotImplementedException();
        }

        public bool Login(string Email, string Password)
        {
            // return context.Admins.FirstOrDefault(a=> a.Email == Email && a.Password == Password) != default;
            throw new NotImplementedException();
        }
    }
}