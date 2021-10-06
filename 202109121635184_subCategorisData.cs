namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subCategorisData : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[EvalSubCatogories] ON
INSERT INTO [dbo].[EvalSubCatogories] ([Id], [CategoryId], [Name]) VALUES (1, 1, N'??????')
INSERT INTO [dbo].[EvalSubCatogories] ([Id], [CategoryId], [Name]) VALUES (2, 1, N'?????')
SET IDENTITY_INSERT [dbo].[EvalSubCatogories] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
