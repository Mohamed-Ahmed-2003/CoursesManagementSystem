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
    public class LessonService : ILesson
    {
        private readonly MyAppContext context = new MyAppContext();

        public void Add( Lesson lesson)
        {
             context.Lessons.Add(lesson);
            context.SaveChanges();
        }

        public Lesson GetLesson(int Id)
        {
            return context.Lessons.Find(Id);
        }

        public void Remove(Lesson lesson)
        {
            context.Lessons.Remove(lesson);
            context.SaveChanges();

        }

        public void Update(Lesson modifiedLesson)
        {
            var oldLesson = context.Lessons.Find(modifiedLesson.Id);
            if (oldLesson != null)
            {
                oldLesson.Title = modifiedLesson.Title;
                oldLesson.Duration = modifiedLesson.Duration;
                oldLesson.OrderNumber = modifiedLesson.OrderNumber;
                context.SaveChanges();
            }
        }

       
    }
}