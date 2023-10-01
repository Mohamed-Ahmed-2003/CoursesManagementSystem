using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CoursesManagementSystem.Services
{
    public class TraineeCourseService : ITraineeCourseService
    {
        public static MyAppContext context = new MyAppContext();

        public IEnumerable<Trainee> GetTraineesByCourseID(int? courseID)
        {
            var traineesCourse = context.Courses.Include(c => c.Trainees).FirstOrDefault(c => c.Id == courseID)?.Trainees;
            return traineesCourse;
        }

        public IEnumerable<Trainee> ReadAll()
        {
            var traineesCourse = context.Courses.Include(c => c.Trainees).SelectMany(c=> c.Trainees).ToList();
            return traineesCourse;
        }
    }
}