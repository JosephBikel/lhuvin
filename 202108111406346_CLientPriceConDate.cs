namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CLientPriceConDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientPrices", "ConfirmationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientPrices", "ConfirmationDate");
        }
    }
}
