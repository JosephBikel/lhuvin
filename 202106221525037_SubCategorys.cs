namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategorys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EvalHeaders", name: "CategoryId", newName: "SubCatogoryId");
            RenameIndex(table: "dbo.EvalHeaders", name: "IX_CategoryId", newName: "IX_SubCatogoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EvalHeaders", name: "IX_SubCatogoryId", newName: "IX_CategoryId");
            RenameColumn(table: "dbo.EvalHeaders", name: "SubCatogoryId", newName: "CategoryId");
        }
    }
}
