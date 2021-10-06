namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class EvalData : DbMigration
    {
        public override void Up()
        {
            /*var EvalCategoriesFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlFiles/dbo.EvalCategories.data.sql");
            var EvalSubCategoriesFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlFiles/dbo.EvalSubCatogories.data.sql");
            var EvalHeadersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlFiles/dbo.EvalHeaders.data.sql");
            var EvalDetailsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlFiles/dbo.EvalDetails.data.sql");

            SqlFile(EvalCategoriesFile);
            SqlFile(EvalSubCategoriesFile);
            SqlFile(EvalHeadersFile);
            SqlFile(EvalDetailsFile);
           */
            Sql("SET IDENTITY_INSERT [dbo].[EvalCategories] ON insert into EvalCategories(Name, Id)values(N'????',  )SET IDENTITY_INSERT [dbo].[EvalCategories] OFF");       
        }

        public override void Down()
        {
        }
    }
}
