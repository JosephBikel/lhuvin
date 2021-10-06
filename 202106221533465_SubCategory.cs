namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EvalHeaders", "EvalCategory_Id", "dbo.EvalCategories");
            DropIndex("dbo.EvalHeaders", new[] { "EvalCategory_Id" });
            DropColumn("dbo.EvalHeaders", "EvalCategory_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EvalHeaders", "EvalCategory_Id", c => c.Int());
            CreateIndex("dbo.EvalHeaders", "EvalCategory_Id");
            AddForeignKey("dbo.EvalHeaders", "EvalCategory_Id", "dbo.EvalCategories", "Id");
        }
    }
}
