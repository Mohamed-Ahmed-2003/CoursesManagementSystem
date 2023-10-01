namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trainerEmailupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Email", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Email", c => c.String(maxLength: 100));
        }
    }
}
