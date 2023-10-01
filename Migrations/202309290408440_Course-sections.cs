namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coursesections : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            RenameColumn(table: "dbo.Lessons", name: "CourseId", newName: "Course_Id");
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LessonsCount = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            AddColumn("dbo.Lessons", "SectionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lessons", "Course_Id", c => c.Int());
            CreateIndex("dbo.Lessons", "SectionId");
            CreateIndex("dbo.Lessons", "Course_Id");
            AddForeignKey("dbo.Lessons", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "Course_Id", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Lessons", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "CourseId", "dbo.Courses");
            DropIndex("dbo.Sections", new[] { "CourseId" });
            DropIndex("dbo.Lessons", new[] { "Course_Id" });
            DropIndex("dbo.Lessons", new[] { "SectionId" });
            AlterColumn("dbo.Lessons", "Course_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Lessons", "SectionId");
            DropTable("dbo.Sections");
            RenameColumn(table: "dbo.Lessons", name: "Course_Id", newName: "CourseId");
            CreateIndex("dbo.Lessons", "CourseId");
            AddForeignKey("dbo.Lessons", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
