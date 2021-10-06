namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoiceDetaildReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Detaild", c => c.Boolean(nullable: false));
            AddColumn("dbo.Invoices", "Report", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Report");
            DropColumn("dbo.Invoices", "Detaild");
        }
    }
}
