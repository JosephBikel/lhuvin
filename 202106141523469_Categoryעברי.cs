namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categoryעברי : DbMigration
    {
        public override void Up()
        {
            Sql("insert into EvalCategories(Name)values(N'עברי')");
        }
        
        public override void Down()
        {
        }
    }
}
