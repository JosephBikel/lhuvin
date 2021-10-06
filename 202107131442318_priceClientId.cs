namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceClientId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PricePerHours", "ClientId", c => c.Int(nullable: true));
            CreateIndex("dbo.PricePerHours", "ClientId");
            AddForeignKey("dbo.PricePerHours", "ClientId", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PricePerHours", "ClientId", "dbo.Clients");
            DropIndex("dbo.PricePerHours", new[] { "ClientId" });
            DropColumn("dbo.PricePerHours", "ClientId");
        }
    }
}
