namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chargeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCardCharges", "PaymentId", "dbo.Payments");
            DropPrimaryKey("dbo.CreditCardCharges");
            AddColumn("dbo.Payments", "ChargeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CreditCardCharges", "PaymentId");
            AddForeignKey("dbo.CreditCardCharges", "PaymentId", "dbo.Payments", "Id");
            DropColumn("dbo.CreditCardCharges", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCardCharges", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.CreditCardCharges", "PaymentId", "dbo.Payments");
            DropPrimaryKey("dbo.CreditCardCharges");
            DropColumn("dbo.Payments", "ChargeId");
            AddPrimaryKey("dbo.CreditCardCharges", "Id");
            AddForeignKey("dbo.CreditCardCharges", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true);
        }
    }
}
