namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyClientWeek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientWeeks", "BalanceDue", c => c.Decimal(nullable: false, precision: 8, scale: 2));
            DropColumn("dbo.ClientWeeks", "OnBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientWeeks", "OnBalance", c => c.Boolean(nullable: false));
            DropColumn("dbo.ClientWeeks", "BalanceDue");
        }
    }
}
