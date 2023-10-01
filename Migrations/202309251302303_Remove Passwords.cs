namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePasswords : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Trainees", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainees", "Password", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
