namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coursesectionsrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "Course_Id" });
            DropColumn("dbo.Lessons", "Course_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Course_Id", c => c.Int());
            CreateIndex("dbo.Lessons", "Course_Id");
            AddForeignKey("dbo.Lessons", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
