namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientEvalStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientEvalDetails", "Status", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientEvalDetails", "Status");
        }
    }
}
