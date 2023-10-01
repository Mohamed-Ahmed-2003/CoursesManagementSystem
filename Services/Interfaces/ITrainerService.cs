using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface ITrainerService
    {
        IEnumerable<Trainer> ReadAll();
        bool Add(Trainer trainer);
        Trainer GetTrainerById(int id);
        bool IsEmailExisted(string email);
        bool Update(int id ,Trainer trainer);
        void Delete(int Id);
    }
}
