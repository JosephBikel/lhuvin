namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyCCCharge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCardCharges", "PaymentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditCardCharges", "PaymentId");
            AddForeignKey("dbo.CreditCardCharges", "PaymentId", "dbo.Payments", "Id", cascadeDelete: false);
            DropColumn("dbo.CreditCardCharges", "Date");
            DropColumn("dbo.CreditCardCharges", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCardCharges", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CreditCardCharges", "Date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.CreditCardCharges", "PaymentId", "dbo.Payments");
            DropIndex("dbo.CreditCardCharges", new[] { "PaymentId" });
            DropColumn("dbo.CreditCardCharges", "PaymentId");
        }
    }
}
