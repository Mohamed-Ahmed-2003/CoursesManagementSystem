namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseModify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "trainer_Id", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "trainer_Id" });
            RenameColumn(table: "dbo.Courses", name: "trainer_Id", newName: "TrainerId");
            AlterColumn("dbo.Courses", "TrainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "TrainerId");
            AddForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            AlterColumn("dbo.Courses", "TrainerId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "TrainerId", newName: "trainer_Id");
            CreateIndex("dbo.Courses", "trainer_Id");
            AddForeignKey("dbo.Courses", "trainer_Id", "dbo.Trainers", "Id");
        }
    }
}
