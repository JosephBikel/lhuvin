namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientPricesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientPrices",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        PerHourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.PricePerHours", t => t.PerHourId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PerHourId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientPrices", "PerHourId", "dbo.PricePerHours");
            DropForeignKey("dbo.ClientPrices", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientPrices", new[] { "PerHourId" });
            DropIndex("dbo.ClientPrices", new[] { "ClientId" });
            DropTable("dbo.ClientPrices");
        }
    }
}
