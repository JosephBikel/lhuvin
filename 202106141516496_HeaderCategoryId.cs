namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeaderCategoryId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EvalHeaders", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.EvalHeaders", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EvalHeaders", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.EvalHeaders", name: "CategoryId", newName: "Category_Id");
        }
    }
}
