using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface IAdminService
    {
        bool Login(string Email, string Password);
        bool ChangePassword (string Email, string Password);
        bool ForgotPassword(string Email);

    }
}
