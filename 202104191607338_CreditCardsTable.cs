namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditCardsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false, maxLength: 20),
                        ExpMonth = c.Byte(nullable: false),
                        ExpYear = c.Short(nullable: false),
                        SecurityCode = c.Short(nullable: false),
                        Zip = c.String(maxLength: 10),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "ClientId", "dbo.Clients");
            DropIndex("dbo.CreditCards", new[] { "ClientId" });
            DropTable("dbo.CreditCards");
        }
    }
}
