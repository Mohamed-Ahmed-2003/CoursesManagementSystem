using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace CoursesManagementSystem.Services.Interfaces
{
    public class CategoryService : ICategoryService
    {
        public static MyAppContext context = new MyAppContext();

        public Category GetCategoryByName (string categoryName)
        {
            var category = context.Categories.FirstOrDefault(c => c.Name ==  categoryName);

            return category;
        }
        public bool Add(Category category)
        {
            if (context.Categories.FirstOrDefault(c => c.Name.ToLower() == category.Name.ToLower()) != default)
                return false;
            context.Categories.Add(category);
            context.SaveChanges();
            return true;
        }

        public void Delete(int Id)
        {
            var category = GetCategory(Id);
            if (category != null)
            {
                var coursesToUpdate = context.Courses.Where(c => c.CategoryId == Id);

                foreach (var course in coursesToUpdate)
                {
                    course.CategoryId = null;
                }

                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }


        public Category GetCategory(int? id)
        {
            var category = context.Categories.Find(id);
            return category;
        }

        public List<Category> GetParentCategoriesById(int? categoryId)
        {
            var parentCategories = new Stack<Category>();
            Category category;

            do
            {
                category = GetCategory(categoryId);

                if (category != null)
                {
                    parentCategories.Push(category);
                    categoryId = category.ParentId ?? 0; // Handle null ParentId
                }
            }
            while (category?.ParentId != null);

            return parentCategories?.ToList();
        }

        public List<Category> ReadAll()
        {
            return context.Categories
                .Include(c => c.ParentCategory) // Include the ParentCategory navigation property
               ?.ToList();
        }


        public bool Update(Category ModifiedCategory)
        {
           var category = context.Categories.Find(ModifiedCategory.Id);

         if (context.Categories.FirstOrDefault(c => c.Name.ToLower() == ModifiedCategory.Name.ToLower() 
                                             && c.Id!=ModifiedCategory.Id) != default)
                return false;

            category.Name = ModifiedCategory.Name;
            category.ParentId= ModifiedCategory.ParentId;

            context.SaveChanges();
            return true;
        }

      
    }
}