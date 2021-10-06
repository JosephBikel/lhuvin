namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CLientPriceId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientPrices", "ClientId", "dbo.Clients");
            DropPrimaryKey("dbo.ClientPrices");
            AddColumn("dbo.ClientPrices", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ClientPrices", "Id");
            AddForeignKey("dbo.ClientPrices", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientPrices", "ClientId", "dbo.Clients");
            DropPrimaryKey("dbo.ClientPrices");
            DropColumn("dbo.ClientPrices", "Id");
            AddPrimaryKey("dbo.ClientPrices", "ClientId");
            AddForeignKey("dbo.ClientPrices", "ClientId", "dbo.Clients", "Id");
        }
    }
}
