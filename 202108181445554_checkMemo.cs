namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkMemo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TPChecks", "Memo", c => c.String());
            DropColumn("dbo.TPChecks", "WrittenTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TPChecks", "WrittenTo", c => c.String());
            DropColumn("dbo.TPChecks", "Memo");
        }
    }
}
