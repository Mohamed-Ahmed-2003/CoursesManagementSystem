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

        public bool Enroll(TraineeCourse model)
        {
            try
            {
                context.TraineeCourses.Add(model);

                context.SaveChanges();
            } 
            catch (Exception ex) {

                throw new Exception($"Error while Enrolling {ex.Message}");
            }
            return true;
        }
        public void UnEnroll (int tID ,int cID )
        {
            var tc = context.TraineeCourses
                .FirstOrDefault(TC => TC.TraineeID == tID && TC.CourseID == cID);
            context.TraineeCourses.Remove(tc);
            context.SaveChanges();
        }
        public IEnumerable<Course> GetCoursesByTraineeID(int? traineeID)
        {
            var courses = context.TraineeCourses
                .Include(tc=>tc.Course)
                .Where(tc=>tc.TraineeID == traineeID)
                .Select(tc=>tc.Course);
            return courses
                ;
        }
        
        public IEnumerable<TraineeCourse> GetTraineesByTrainerID(int? TrainerID)
        {
            var traineesCourses =
                context
                .TraineeCourses
                .Include(tc => tc.Trainee)
                .Include(tc => tc.Course)
                .Where(tc => tc.Course.TrainerId == (int)TrainerID);
            return traineesCourses;
        }
        public IEnumerable<Trainee> GetTraineesByCourseID(int? courseID)
        {
            var traineesCourse = context.TraineeCourses
                .Include(tc=>tc.Trainee)
                .Where(c => c.CourseID == courseID)
                .Select(tc=>tc.Trainee);
            return traineesCourse;
        }

        public IEnumerable<Trainee> ReadAll()
        {
            var traineesCourse = context.TraineeCourses.Include(tc => tc.Trainee).Select(tc=> tc.Trainee);
            return traineesCourse;
        }
        public int? AddedReview(int courseID, int traineeID)
        {
            return context.TraineeCourses.FirstOrDefault(tc => tc.CourseID == courseID && tc.TraineeID == traineeID).Rating;
        }
        public bool IsEnrolled(int courseID , int traineeID)
        {
            return context.TraineeCourses.Any(tc => tc.CourseID == courseID && tc.TraineeID == traineeID);
        }

        public void AddReview(TraineeCourse TC)
        {
            var target = context.TraineeCourses.FirstOrDefault(tc => tc.TraineeID == TC.TraineeID && tc.CourseID == TC.CourseID);
            target.ReviewDate = TC.ReviewDate;
            target.ReviewTitle = TC.ReviewTitle;
            target.Review = TC.Review;
            target.Rating = TC.Rating;

            context.SaveChanges();
        }
        public IEnumerable<TraineeCourse> GetTCInfoById(int courseID)
        {
            return context.TraineeCourses.Include(tc=>tc.Course).Include(tc=>tc.Trainee)
                .Where(tc => tc.CourseID == courseID).ToList();
        }
    }
}