using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services.Interfaces;
using CoursesManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using CoursesManagementSystem.ViewModels;

namespace CoursesManagementSystem.Services
{
    
    public enum SortType { 
        MostRelvant,
        MostTrainees,
        Newest,
        MostReviewed, 
        HighestRated
    }
    public class Utility
    {
        private static readonly CategoryService categoryService = new CategoryService();
        private static List<Category> cachedCategories;
      

        public static List<Category> GetCategories()
        {
           

            return categoryService.ReadAll();
        }
  
        
        public static SelectList GetSortTypes()
        {
            return new SelectList(
                Enum.GetValues(typeof(SortType))
                    .Cast<SortType>()
                    .Select(ST => new {
                        value = ST.ToString(),
                        Text = ST.ToString()
                    }),
                      "Value", "Text");
        }

        public static string[] ParseString(string promises)
        {
            if (string.IsNullOrEmpty(promises)) return new string[0] ;
            string[] words = promises.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        public static string CalcDuration (int minutes)
        {
            var duration = TimeSpan.FromMinutes(minutes);

            int Hours = duration.Hours;
            int Minutes= duration.Minutes;

            if (Hours > 0 && minutes > 0)
                return $"{Hours} H : {Minutes} M";
            else if (Minutes > 0)
                return $"{Minutes} M";

                return $"{Hours} H";

        }
    }

}