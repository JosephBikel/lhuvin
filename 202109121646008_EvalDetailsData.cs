namespace Lhuvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvalDetailsData : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[EvalDetails] ON
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1002, N'??? ? ????? ??', 1026, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1003, N'???? ?????????', 1026, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1004, N'???? ????????? ? ???', 1026, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1005, N'???? ????????? ? ??', 1026, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1006, N'???? ????????? ? ??? ???? ??? ???? ? ?-?-?', 1026, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1007, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1008, N'??', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1009, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1010, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1011, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1012, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1013, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1014, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1015, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1016, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1017, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1018, N'??', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1019, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1020, N'??', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1021, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1022, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1023, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1024, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1025, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1026, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1027, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1028, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1029, N'??', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1030, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1031, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1032, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1033, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1034, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1035, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1036, N'??', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1037, N'??', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1038, N'??', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (1039, N'?', 1028, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2002, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2003, N'??', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2004, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2005, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2006, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2007, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2008, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2009, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2010, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2011, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2012, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2013, N'??', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2014, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2015, N'??', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2016, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2017, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2018, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2019, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2020, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2021, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2022, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2023, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2024, N'??', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2025, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2026, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2027, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2028, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2029, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2030, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2031, N'??', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2032, N'??', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2033, N'??', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2034, N'?', 1029, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2035, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2036, N'??', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2037, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2038, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2039, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2040, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2041, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2042, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2043, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2044, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2045, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2046, N'??', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2047, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2048, N'??', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2049, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2050, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2051, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2052, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2053, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2054, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2055, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2056, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2057, N'??', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2058, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2059, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2060, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2061, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2062, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2063, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2064, N'??', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2065, N'??', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2066, N'??', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (2067, N'?', 1030, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3002, N'1 ??? ?????? ?????', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3003, N'1 ??? ??????? ?????', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3004, N'2 ???''? ??????? ?????', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3005, N'2 ???''? ??????? ?????
', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3006, N'1 ??? ???? ? ?-?-?', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3007, N'???????? � ?? ??? ??? ???? ?? ?????
', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3008, N'???????? - ?? ??? ??? ???? ?? ???????', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3009, N'?????''? - ?? ??? ??? ???? ?? ?????
', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3010, N'?????''? - ?? ??? ??? ???? ?? ???????', 1025, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3011, N'??? ? ??? ?????', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3012, N'?? ?????? ?????', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3013, N'??', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3014, N'??', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3015, N'??', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3016, N'????', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3017, N'???', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3018, N'????', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3019, N'????', 1027, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3020, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3021, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3022, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3023, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3024, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3025, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3026, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3027, N'?', 1021, NULL)
INSERT INTO [dbo].[EvalDetails] ([Id], [Name], [HeaderId], [EvalSubCatogory_Id]) VALUES (3028, N'??', 1021, NULL)
SET IDENTITY_INSERT [dbo].[EvalDetails] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
