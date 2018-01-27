namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'72d21e27-260c-4302-9faf-b3f7350d290b', N'admin@vidley.com', 0, N'ACPGkmPSGZCNgZD1jw8JRMZwMTKWQ/PH1HP+Ka++49ioVmH/7UAUif+dJaevJ47gAA==', N'7b4775a1-4f86-4ed3-8975-92accb603155', NULL, 0, 0, NULL, 1, 0, N'admin@vidley.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7799c50a-b62d-4184-a03c-47b1d618684a', N'guest@vidly.com', 0, N'ADCDfFsK8naxzKX3gcTvuIU/CwYp/dTtOb7UkkO6B0JZ4qKJlmbfbLHd7QKKDwS9FA==', N'907514f2-cecf-4ec3-a4c9-e094eb2327fa', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad10dec3-a87f-484b-a580-cdfa286957a9', N'osundal83@gmail.com', 0, N'AIl3N68IhZxU3plDrXbzh+SJcicw1fABtga9f3+KiSM2ZsT/xDRFNxgxpwkdSshC0w==', N'2816d229-c88a-43f6-9b1a-aae712af1135', NULL, 0, 0, NULL, 1, 0, N'osundal83@gmail.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'16455939-8edf-469e-b665-6a18775cbc8a', N'CanManageMovie')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
