using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface ITraineeService
    {
        IEnumerable<Trainee> ReadAll();
        bool Add(Trainee trainer);
        Trainee GetTraineeById(int id);
        bool IsEmailExisted(string email);
        bool Update(int id ,Trainee trainer);
        void Delete(int Id);
    }
}
