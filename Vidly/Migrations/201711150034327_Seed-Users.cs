namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'34472624-f5d1-440f-875b-2287ab72857d', N'Admin@vidly.com', 0, N'AFzxqJmrNIJ+tngsQtwRFkEqU7FIc6WzbaMRFgAcCNZD1VNz6L5K//zZPKqmaK3H6g==', N'5312ee6d-cf24-4987-b13d-533beb75cc65', NULL, 0, 0, NULL, 1, 0, N'Admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7e051551-f2fa-46c5-a7bc-386add7a69e2', N'guest@vidly.com', 0, N'AMyOC8oi2DhdbDZIIGHZkDxNgf29E5BIZq5XwNVyECjrXnyBWQGu94TCYC17U33Hqw==', N'c7093476-cdca-4fbb-af94-13c72614eb0b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6ed61d2d-03a2-476e-93e4-c32d3ac33c96', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34472624-f5d1-440f-875b-2287ab72857d', N'6ed61d2d-03a2-476e-93e4-c32d3ac33c96')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
