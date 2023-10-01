namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sectionsLesonupdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Duration", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "Duration");
        }
    }
}
