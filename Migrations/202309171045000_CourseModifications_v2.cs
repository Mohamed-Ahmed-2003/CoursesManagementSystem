namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModifications_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ImageUrl");
        }
    }
}
