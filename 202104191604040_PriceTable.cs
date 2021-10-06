namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PricePerHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 50),
                        Public = c.Boolean(nullable: false),
                        ConfirmationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Description, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PricePerHours", new[] { "Description" });
            DropTable("dbo.PricePerHours");
        }
    }
}
