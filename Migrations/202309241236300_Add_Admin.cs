namespace CoursesManagementSystem.Migrations
{
    using CoursesManagementSystem.Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Admin : DbMigration
    {
        public override void Up()
        {
            // Your schema changes here (e.g., CreateTable, AddColumn, etc.)

            // Create the Administrator role if it doesn't exist
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MyAppContext()));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            // Create an Admin user (you can replace these values with actual admin credentials)
            var userManager = new UserManager<MyIdentityUser>(new UserStore<MyIdentityUser>(new MyAppContext()));
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


        }

        public override void Down()
        {
        }
    }
}
