namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvalHeaderIdNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EvalHeaders", new[] { "HeaderId" });
            AlterColumn("dbo.EvalHeaders", "HeaderId", c => c.Int());
            CreateIndex("dbo.EvalHeaders", "HeaderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EvalHeaders", new[] { "HeaderId" });
            AlterColumn("dbo.EvalHeaders", "HeaderId", c => c.Int(nullable: false));
            CreateIndex("dbo.EvalHeaders", "HeaderId");
        }
    }
}
