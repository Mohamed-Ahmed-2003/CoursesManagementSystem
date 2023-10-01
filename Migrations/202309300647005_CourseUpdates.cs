namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Topics", c => c.String());
            DropColumn("dbo.Courses", "TopicsTopics");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "TopicsTopics", c => c.String());
            DropColumn("dbo.Courses", "Topics");
        }
    }
}
