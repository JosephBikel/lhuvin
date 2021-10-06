namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FatherName = c.String(maxLength: 50),
                        Grade = c.String(maxLength: 10),
                        DOB = c.DateTime(),
                        HomePhone = c.String(nullable: false, maxLength: 15),
                        FathersCellNumber = c.String(maxLength: 15),
                        MothersCellNumber = c.String(maxLength: 15),
                        Address = c.String(maxLength: 100),
                        Unit = c.String(maxLength: 5),
                        City = c.String(maxLength: 25),
                        State = c.String(maxLength: 25),
                        Zip = c.String(maxLength: 10),
                        EmailAddress = c.String(maxLength: 100),
                        ConfirmationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.HomePhone, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clients", new[] { "HomePhone" });
            DropTable("dbo.Clients");
        }
    }
}
