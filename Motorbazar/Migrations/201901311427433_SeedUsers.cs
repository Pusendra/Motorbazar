namespace Motorbazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6a0c61ca-0880-4b5f-adea-2056b50da7db', N'admin@mb.com', 0, N'AOR6Y6jDaxIA3kWLv2P7NFMRxgUqt3RsjzrVGRCTBtz/T3FoQmUSQdOyNDPb0t66Lw==', N'7fc035e1-253f-4081-926a-d6f03404da7a', NULL, 0, 0, NULL, 1, 0, N'admin@mb.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e410eaef-0f92-427c-aee3-f4873d24e34c', N'guest@mb.com', 0, N'AEDYvivavs3j54sIDDnHgOt8I4rhHwO2jwMRj3sSHnbeXbedDNOJhoICeFijYS6cRA==', N'a82027b1-e166-48f0-8de5-bad00dc5b7b5', NULL, 0, 0, NULL, 1, 0, N'guest@mb.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6d72ce2e-3f43-471b-953d-d7080f8cdb4a', N'CanManageVehicles')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6a0c61ca-0880-4b5f-adea-2056b50da7db', N'6d72ce2e-3f43-471b-953d-d7080f8cdb4a')
");
        }
        
        public override void Down()
        {
        }
    }
}
