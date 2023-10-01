using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Services
{
    public class SectionService : ISection
    {
        private readonly MyAppContext context = new MyAppContext();

        public void Add( Section section)
        {
             context.Sections.Add(section);

            context.SaveChanges();
        }

        public Section GetSectionById(int Id)
        {
            return context.Sections
                          .Include(s => s.Lessons)  // Include the Lessons related to the Section
                          .FirstOrDefault(s => s.Id == Id);
        }

        public IEnumerable<Section> ReadAll(int ?Id)
        {
            return context.Sections.Where(s=>s.CourseId == Id).Include(s=>s.Lessons).ToList();
        }

        public void Remove(Section section)
        {
            context.Sections.Remove(section);
            context.SaveChanges();

        }

        public void Update(Section modifiedSection)
        {
            var oldSection = context.Sections.Find(modifiedSection.Id);
            if (oldSection != null)
            {
                oldSection.Name = modifiedSection.Name;
                context.SaveChanges();
            }
        }

       
    }
}