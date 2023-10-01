using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface ILesson
    {

        Lesson GetLesson(int Id);
        void Add (Lesson lesson);
        void Update (Lesson lesson);
        void Remove (Lesson lesson);
    }
}
