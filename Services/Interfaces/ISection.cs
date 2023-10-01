using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesManagementSystem.Services.Interfaces
{
    internal interface ISection
    {

        IEnumerable<Section> ReadAll(int? Id);
        void Add (Section section);
        void Update (Section section);
        void Remove (Section section);
        Section GetSectionById (int id);

    }
}
