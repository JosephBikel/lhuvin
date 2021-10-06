namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientDay_WeekTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        ClientId = c.Int(nullable: false),
                        Learnd = c.Boolean(nullable: false),
                        BreakDown = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.ClientWeeks", t => t.WeekId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.WeekId);
            
            CreateTable(
                "dbo.ClientWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ParshaId = c.Int(nullable: false),
                        OnBalance = c.Boolean(nullable: false),
                        Billed = c.Boolean(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ParshaWeeks", t => t.ParshaId, cascadeDelete: true)
                .Index(t => t.ParshaId)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientWeeks", "ParshaId", "dbo.ParshaWeeks");
            DropForeignKey("dbo.ClientDays", "WeekId", "dbo.ClientWeeks");
            DropForeignKey("dbo.ClientWeeks", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientDays", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientWeeks", new[] { "ClientId" });
            DropIndex("dbo.ClientWeeks", new[] { "ParshaId" });
            DropIndex("dbo.ClientDays", new[] { "WeekId" });
            DropIndex("dbo.ClientDays", new[] { "ClientId" });
            DropTable("dbo.ClientWeeks");
            DropTable("dbo.ClientDays");
        }
    }
}
