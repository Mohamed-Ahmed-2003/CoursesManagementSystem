using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Data.Entity;
using CoursesManagementSystem.Areas.Admin.Controllers;
using System.Linq.Expressions;
using CoursesManagementSystem.Controllers;

namespace CoursesManagementSystem.Services.Interfaces
{
    public class CourseService : ICourseService
    {
        public static readonly  MyAppContext context = new MyAppContext();

        public void Add(Course  course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Courses.Remove(GetCourse(Id));
            context.SaveChanges();
        }

        public Course GetCourse(int id)
        {
            var course = context.Courses.Include(c => c.Sections).FirstOrDefault(c => c.Id == id);
            return course;
        } 
        public IEnumerable<Course> SearchCourses(string input)
        {
            
            return context.Courses.Include(c=>c.Trainer)
                                  .Where(c=>c.Name.Contains(input) || 
                                        c.Trainer.Name.Contains(input)||
                                        c.Category.Name.Contains(input) ||
                                        (c.Category.ParentCategory != null && c.Category.ParentCategory.Name.Contains(input))
                                        ).ToList();
        }

        public IEnumerable<Course> Sort(string input, SortType sortType)
        {
            IQueryable<Course> CoursesQuery = context.Courses.Where(c => input == null ||
                                                        c.Name.Contains(input) ||
                                                        c.Trainer.Name.Contains(input) ||
                                                        c.Category.Name.Contains(input) ) ;

            IEnumerable<Course> FilteredCourses = new List<Course>();

            switch (sortType) {

                case SortType.MostTrainees:
                    FilteredCourses = CoursesQuery
                        .GroupJoin(
                            context.TraineeCourses,
                            course => course.Id,
                            traineeCourse => traineeCourse.CourseID,
                            (course, traineeCourses) => new
                            {
                                Course = course,
                                TraineeCount = traineeCourses.Count()
                            })
                        .OrderByDescending(result => result.TraineeCount)
                        .Select(result => result.Course)
                        .ToList();

                    break;


                case SortType.Newest:
                    FilteredCourses = CoursesQuery.OrderByDescending(c => c.CreatedDate);
                    break;
                case SortType.HighestRated:
                    FilteredCourses = CoursesQuery.OrderByDescending(c => c.Rating);
                    break;
                case SortType.MostReviewed:
                    FilteredCourses = CoursesQuery.OrderByDescending(c => c.Reviewers);
                    break;

                default:
                    FilteredCourses = CoursesQuery;
                    break;
            }

            return FilteredCourses;
        }

        public IEnumerable<Course> ReadAll()
        {
            return context.Courses.Include(c => c.Category).Include(c => c.Trainer)?.ToList();
        }   
        
        public IEnumerable<Course> GetTrainerCourses(int? id)
        {
            return context.Courses.Where(c => c.TrainerId == id)?.ToList();
        }
       

        public bool Update(Course course)
        {
            var TargetCourse = context.Courses.FirstOrDefault(c => c.Id == course.Id);
            if (TargetCourse is null) return false;

            TargetCourse.TrainerId = course.TrainerId;
            TargetCourse.CategoryId= course.CategoryId;
            TargetCourse.CreatedDate = course.CreatedDate;
            TargetCourse.Description= course.Description;
            TargetCourse.Name = course.Name;
            TargetCourse.ImageUrl = course.ImageUrl;
            context.SaveChanges();
            return true;

        }
    }
}