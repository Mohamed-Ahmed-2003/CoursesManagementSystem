using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services.Interfaces;
using CoursesManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

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
            if (cachedCategories == null)
            {
                // Data is not in cache, so fetch it from the database
                cachedCategories = categoryService.ReadAll();

                // Cache the data for a specified duration (e.g., 15 minutes)
                var cacheDuration = TimeSpan.FromMinutes(60);
                CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.Add(cacheDuration) };
                MemoryCache.Default.Add("CategoriesCacheKey", cachedCategories, policy);
            }

            return cachedCategories;
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
          
            string[] words = promises.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }


    }
}