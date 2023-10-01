namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(),
                        ParentCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_Id)
                .Index(t => t.ParentCategory_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        trainer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.trainer_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.trainer_Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 100),
                        Description = c.String(),
                        Website = c.String(maxLength: 250),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TraineeCourses",
                c => new
                    {
                        Trainee_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainee_Id, t.Course_Id })
                .ForeignKey("dbo.Trainees", t => t.Trainee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Trainee_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.TraineeCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TraineeCourses", "Trainee_Id", "dbo.Trainees");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropIndex("dbo.TraineeCourses", new[] { "Course_Id" });
            DropIndex("dbo.TraineeCourses", new[] { "Trainee_Id" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "trainer_Id" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropTable("dbo.TraineeCourses");
            DropTable("dbo.Trainers");
            DropTable("dbo.Trainees");
            DropTable("dbo.Lessons");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
