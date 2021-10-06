namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EvalHeaders", "EvalSubCatogory_Id", "dbo.EvalSubCatogories");
            DropIndex("dbo.EvalHeaders", new[] { "EvalSubCatogory_Id" });
            RenameColumn(table: "dbo.EvalHeaders", name: "EvalSubCatogory_Id", newName: "SubCatogoryId");
            AlterColumn("dbo.EvalHeaders", "SubCatogoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.EvalHeaders", "SubCatogoryId");
            AddForeignKey("dbo.EvalHeaders", "SubCatogoryId", "dbo.EvalSubCatogories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvalHeaders", "SubCatogoryId", "dbo.EvalSubCatogories");
            DropIndex("dbo.EvalHeaders", new[] { "SubCatogoryId" });
            AlterColumn("dbo.EvalHeaders", "SubCatogoryId", c => c.Int());
            RenameColumn(table: "dbo.EvalHeaders", name: "SubCatogoryId", newName: "EvalSubCatogory_Id");
            CreateIndex("dbo.EvalHeaders", "EvalSubCatogory_Id");
            AddForeignKey("dbo.EvalHeaders", "EvalSubCatogory_Id", "dbo.EvalSubCatogories", "Id");
        }
    }
}
