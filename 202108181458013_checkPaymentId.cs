namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkPaymentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TPChecks", "PaymentId", "dbo.Payments");
            DropPrimaryKey("dbo.TPChecks");
            AddPrimaryKey("dbo.TPChecks", "PaymentId");
            AddForeignKey("dbo.TPChecks", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true );
            DropColumn("dbo.TPChecks", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TPChecks", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.TPChecks", "PaymentId", "dbo.Payments");
            DropPrimaryKey("dbo.TPChecks");
            AddPrimaryKey("dbo.TPChecks", "Id");
            AddForeignKey("dbo.TPChecks", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true);
        }
    }
}
