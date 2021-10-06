namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DayPricph : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientDays", "PricePHId", c => c.Int(nullable: true));
            CreateIndex("dbo.ClientDays", "PricePHId");
            AddForeignKey("dbo.ClientDays", "PricePHId", "dbo.PricePerHours", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientDays", "PricePHId", "dbo.PricePerHours");
            DropIndex("dbo.ClientDays", new[] { "PricePHId" });
            DropColumn("dbo.ClientDays", "PricePHId");
        }
    }
}
