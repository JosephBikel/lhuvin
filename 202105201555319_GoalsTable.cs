namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoalsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientGoals",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        Goal = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete:true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientGoals", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientGoals", new[] { "ClientId" });
            DropTable("dbo.ClientGoals");
        }
    }
}
