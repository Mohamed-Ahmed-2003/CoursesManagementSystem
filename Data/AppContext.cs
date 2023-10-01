using CoursesManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class MyDatabaseInitializer : CreateDatabaseIfNotExists<MyAppContext>
    {
        protected override void Seed(MyAppContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<MyIdentityUser>(new UserStore<MyIdentityUser>(context));

            // Create the Administrator role if it doesn't exist
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            // Create an Admin user (you can replace these values with actual admin credentials)
            var adminUser = new MyIdentityUser
            {
                UserName = "Mo.19.ahmed.47@gmail.com",
                Email = "Mo.19.ahmed.47@gmail.com"
            };

            string adminPassword = "Mohamed-Eissa@2023"; // Replace with a strong admin password

            // Create the Admin user if it doesn't exist
            var user = userManager.FindByName(adminUser.UserName);
            if (user == null)
            {
                var createUserResult = userManager.Create(adminUser, adminPassword);

                if (createUserResult.Succeeded)
                {
                    // Add the user to the Admin role
                    userManager.AddToRole(adminUser.Id, "Admin");
                }
            }

            base.Seed(context);
        }
    }


    public class MyAppContext : IdentityDbContext<MyIdentityUser>
    {
        public MyAppContext() : base("MyConnectionString")
        {
            Database.SetInitializer(new MyDatabaseInitializer());
        }

        // ... other DbSet properties ...

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add your entity configurations here if needed.
        }

        public DbSet<Course>Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<Section> Sections{ get; set; }

      
    }
}