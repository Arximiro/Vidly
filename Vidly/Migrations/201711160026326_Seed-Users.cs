namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a10db7a4-82ca-410b-adc9-6e43d3e65713', N'guest@vidly.com', 0, N'AF74DZAiZxQeeiBjUx5WzHnEPfGgFXMzc2rsYcqhbYF8fi6631cdzmgbR9+VczRggQ==', N'5c785de0-df95-4ddf-809a-de984ba61f32', N'812-324-1234', 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab67572e-31a3-493f-a7b6-ca4ecdb4f5bb', N'admin@vidly.com', 0, N'AI5T2yRGC54eT6aQVtxpo2sTUHKL7AuX66XGfCkPHzA9IERVOb5FBRDx+0jo252eRA==', N'292876de-d058-4280-b339-f1d5edfe6bb0', N'812-314-1441', 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd4d899c1-9b44-4673-93f9-944750a40f6a', N'Manager')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ab67572e-31a3-493f-a7b6-ca4ecdb4f5bb', N'd4d899c1-9b44-4673-93f9-944750a40f6a')");
        }
        
        public override void Down()
        {
        }
    }
}
