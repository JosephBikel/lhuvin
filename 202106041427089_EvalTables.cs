namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvalTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EvalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        HeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvalHeaders", t => t.HeaderId, cascadeDelete: true)
                .Index(t => t.HeaderId);
            
            CreateTable(
                "dbo.EvalHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        HeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvalHeaders", t => t.HeaderId)
                .Index(t => t.HeaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvalDetails", "HeaderId", "dbo.EvalHeaders");
            DropForeignKey("dbo.EvalHeaders", "HeaderId", "dbo.EvalHeaders");
            DropIndex("dbo.EvalHeaders", new[] { "HeaderId" });
            DropIndex("dbo.EvalDetails", new[] { "HeaderId" });
            DropTable("dbo.EvalHeaders");
            DropTable("dbo.EvalDetails");
        }
    }
}
