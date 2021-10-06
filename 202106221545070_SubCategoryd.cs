namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EvalHeaders", "SubCatogoryId", "dbo.EvalSubCatogories");
            DropIndex("dbo.EvalHeaders", new[] { "SubCatogoryId" });
            RenameColumn(table: "dbo.EvalHeaders", name: "SubCatogoryId", newName: "EvalSubCatogory_Id");
            AlterColumn("dbo.EvalHeaders", "EvalSubCatogory_Id", c => c.Int());
            CreateIndex("dbo.EvalHeaders", "EvalSubCatogory_Id");
            AddForeignKey("dbo.EvalHeaders", "EvalSubCatogory_Id", "dbo.EvalSubCatogories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvalHeaders", "EvalSubCatogory_Id", "dbo.EvalSubCatogories");
            DropIndex("dbo.EvalHeaders", new[] { "EvalSubCatogory_Id" });
            AlterColumn("dbo.EvalHeaders", "EvalSubCatogory_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.EvalHeaders", name: "EvalSubCatogory_Id", newName: "SubCatogoryId");
            CreateIndex("dbo.EvalHeaders", "SubCatogoryId");
            AddForeignKey("dbo.EvalHeaders", "SubCatogoryId", "dbo.EvalSubCatogories", "Id", cascadeDelete: true);
        }
    }
}
