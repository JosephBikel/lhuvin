namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BalanceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientBalances",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientBalances", "Id", "dbo.Clients");
            DropIndex("dbo.ClientBalances", new[] { "Id" });
            DropTable("dbo.ClientBalances");
        }
    }
}
