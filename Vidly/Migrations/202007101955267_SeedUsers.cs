namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3965cdd5-6276-4ed5-b0cf-010ae5891418', N'admin@vidly.com', 0, N'AKg9QqbG+2UGFwiUxzsjMftBaJXnUziFUwcFxsPUvbDxK0i8sBAoq3LDWGWZIUx9dw==', N'8481f9b8-c4d9-4a5e-9119-ee7f5bea18d2', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0ae3214-b1f3-458f-a947-5ff8c23050bb', N'aosama314@gmail.com', 0, N'AEBtSiSOAHAO4R9lTRxdbIJ/w0ZY/WD7CyWMN3WwL22JYD0QJotuIh0JvdRKYcG8UA==', N'2132e5b8-3a1d-4751-9e62-f4c2564b4eb9', NULL, 0, 0, NULL, 1, 0, N'aosama314@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0c916610-7bd4-4374-a249-4d859a757fc0', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3965cdd5-6276-4ed5-b0cf-010ae5891418', N'0c916610-7bd4-4374-a249-4d859a757fc0')

");
        }
        
        public override void Down()
        {
        }
    }
}
