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
            throw new NotImplementedException();
        }

        public Course GetCourse(int id)
        {
            return context.Courses.Include(c=>c.Sections).FirstOrDefault(c=>c.Id == id);
        } 
        public IEnumerable<Course> SearchCourses(string input)
        {
            
            return context.Courses.Include(c=>c.trainer)
                                  .Where(c=>c.Name.Contains(input) || 
                                        c.trainer.Name.Contains(input)||
                                        c.category.Name.Contains(input));
        }

        public IEnumerable<Course> Sort(string input, SortType sortType)
        {
            IQueryable<Course> CoursesQuery = context.Courses.Where(c => input == null ||
                                                        c.Name.Contains(input) ||
                                                        c.trainer.Name.Contains(input) ||
                                                        c.category.Name.Contains(input));

            IEnumerable<Course> FilterdCourses = new List<Course>();

            switch (sortType) {

                case SortType.MostTrainees:

                FilterdCourses = CoursesQuery.OrderByDescending(c => c.TraineesCount);
                    break;

                case SortType.Newest:
                  FilterdCourses = CoursesQuery.OrderByDescending(c => c.CreatedDate);
                    break;

                default:
                    FilterdCourses = CoursesQuery;
                    break;
            }

            return FilterdCourses;
        }

        public IEnumerable<Course> ReadAll()
        {
            return context.Courses.Include(c => c.category).Include(c => c.trainer);
        }   
        
        public IEnumerable<Course> GetTrainerCourses(int? id)
        {
            return context.Courses.Where(c=>c.TrainerId == id);
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