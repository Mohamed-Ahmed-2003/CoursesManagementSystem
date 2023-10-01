namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sectionupdates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sections", "LessonsCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sections", "LessonsCount", c => c.Int(nullable: false));
        }
    }
}
