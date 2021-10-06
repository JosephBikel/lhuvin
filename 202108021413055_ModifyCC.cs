namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCards", "Exp", c => c.String(nullable: false));
            AddColumn("dbo.CreditCards", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.CreditCards", "ExpMonth");
            DropColumn("dbo.CreditCards", "ExpYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCards", "ExpYear", c => c.Short(nullable: false));
            AddColumn("dbo.CreditCards", "ExpMonth", c => c.Byte(nullable: false));
            DropColumn("dbo.CreditCards", "Name");
            DropColumn("dbo.CreditCards", "Exp");
        }
    }
}
