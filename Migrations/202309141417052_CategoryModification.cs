namespace CoursesManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryModification : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "ParentId");
            RenameColumn(table: "dbo.Categories", name: "ParentCategory_Id", newName: "ParentId");
            RenameIndex(table: "dbo.Categories", name: "IX_ParentCategory_Id", newName: "IX_ParentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Categories", name: "IX_ParentId", newName: "IX_ParentCategory_Id");
            RenameColumn(table: "dbo.Categories", name: "ParentId", newName: "ParentCategory_Id");
            AddColumn("dbo.Categories", "ParentId", c => c.Int());
        }
    }
}
