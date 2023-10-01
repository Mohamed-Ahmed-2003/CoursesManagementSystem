namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TraineesCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "traineesCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "traineesCount");
        }
    }
}
