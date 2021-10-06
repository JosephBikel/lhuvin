namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CcChargesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCardCharges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CardId = c.Int(nullable: false),
                        Location = c.String(maxLength: 100),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CardId, cascadeDelete: true)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCardCharges", "CardId", "dbo.CreditCards");
            DropIndex("dbo.CreditCardCharges", new[] { "CardId" });
            DropTable("dbo.CreditCardCharges");
        }
    }
}
