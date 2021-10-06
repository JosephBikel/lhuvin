namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategorysTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EvalCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EvalHeaders", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.EvalHeaders", "Category_Id");
            AddForeignKey("dbo.EvalHeaders", "Category_Id", "dbo.EvalCategories", "Id", cascadeDelete: true);
            DropColumn("dbo.EvalHeaders", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EvalHeaders", "Category", c => c.Byte(nullable: false));
            DropForeignKey("dbo.EvalHeaders", "Category_Id", "dbo.EvalCategories");
            DropIndex("dbo.EvalHeaders", new[] { "Category_Id" });
            DropColumn("dbo.EvalHeaders", "Category_Id");
            DropTable("dbo.EvalCategories");
        }
    }
}
