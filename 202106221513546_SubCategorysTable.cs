namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategorysTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EvalHeaders", "CategoryId", "dbo.EvalCategories");
            CreateTable(
                "dbo.EvalSubCatogories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvalCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.EvalDetails", "EvalSubCatogory_Id", c => c.Int());
            AddColumn("dbo.EvalHeaders", "EvalCategory_Id", c => c.Int());
            CreateIndex("dbo.EvalDetails", "EvalSubCatogory_Id");
            CreateIndex("dbo.EvalHeaders", "EvalCategory_Id");
            AddForeignKey("dbo.EvalDetails", "EvalSubCatogory_Id", "dbo.EvalSubCatogories", "Id");
            AddForeignKey("dbo.EvalHeaders", "EvalCategory_Id", "dbo.EvalCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvalHeaders", "EvalCategory_Id", "dbo.EvalCategories");
            DropForeignKey("dbo.EvalDetails", "EvalSubCatogory_Id", "dbo.EvalSubCatogories");
            DropForeignKey("dbo.EvalSubCatogories", "CategoryId", "dbo.EvalCategories");
            DropIndex("dbo.EvalSubCatogories", new[] { "CategoryId" });
            DropIndex("dbo.EvalHeaders", new[] { "EvalCategory_Id" });
            DropIndex("dbo.EvalDetails", new[] { "EvalSubCatogory_Id" });
            DropColumn("dbo.EvalHeaders", "EvalCategory_Id");
            DropColumn("dbo.EvalDetails", "EvalSubCatogory_Id");
            DropTable("dbo.EvalSubCatogories");
            AddForeignKey("dbo.EvalHeaders", "CategoryId", "dbo.EvalCategories", "Id", cascadeDelete: true);
        }
    }
}
