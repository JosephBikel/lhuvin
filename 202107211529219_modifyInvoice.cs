namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Subtotal", c => c.Decimal(nullable: false, precision: 8, scale: 2));
            AddColumn("dbo.Invoices", "PreviousBalance", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AddColumn("dbo.Invoices", "AmountPaid", c => c.Decimal(nullable: false, precision: 8, scale: 2));
            AddColumn("dbo.Invoices", "TotalBalance", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            DropColumn("dbo.Invoices", "PriceSum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "PriceSum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Invoices", "TotalBalance");
            DropColumn("dbo.Invoices", "AmountPaid");
            DropColumn("dbo.Invoices", "PreviousBalance");
            DropColumn("dbo.Invoices", "Subtotal");
        }
    }
}
