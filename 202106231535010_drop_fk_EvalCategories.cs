namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_fk_EvalCategories : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE EvalHeaders drop CONSTRAINT[FK_dbo.EvalHeaders_dbo.EvalCategories_Category_Id]");
        }
        
        public override void Down()
        {
        }
    }
}
