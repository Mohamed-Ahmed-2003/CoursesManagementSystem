using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface ICategoryService
    {
      List<Category> ReadAll ();
        bool Add (Category category);
        Category GetCategory (int? id);
        bool Update (Category category);
        void Delete (int Id);

       
    }
}
