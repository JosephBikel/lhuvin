namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvalHeadersData : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[EvalHeaders] ON
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1020, '??????', NULL, 1)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1021, N'??????', NULL, 1)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1022, N'??? ?????', NULL, 1)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1023, N'??????', NULL, 1)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1024, N'????????? ???? ???', NULL, 1)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1025, N'???? ???', NULL, 2)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1026, N'???? ???', NULL, 2)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1027, N'??? ?????', NULL, 2)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1028, N'?????', 1020, 1)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1029, N'????', 1020, 1)
INSERT INTO [dbo].[EvalHeaders] ([Id], [Name], [HeaderId], [SubCatogoryId]) VALUES (1030, N'???', 1020, 1)
SET IDENTITY_INSERT [dbo].[EvalHeaders] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
