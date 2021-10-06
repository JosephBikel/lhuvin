namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPChecksTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TPChecks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WrittenTo = c.String(),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: false)
                .Index(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TPChecks", "PaymentId", "dbo.Payments");
            DropIndex("dbo.TPChecks", new[] { "PaymentId" });
            DropTable("dbo.TPChecks");
        }
    }
}
