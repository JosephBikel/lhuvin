namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParshasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParshaWeeks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParshaWeeks");
        }
    }
}
