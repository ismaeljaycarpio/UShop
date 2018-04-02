namespace UShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'22ac6c9f-1526-4cce-9d2c-ae7e37390b36', N'admin@ushop.com', 0, N'AN4+nOfkk80WgD25PgiPy10CoKu4OjhSq2GuchOMYxNakETYsye+GkT9zIPDjZHQzg==', N'9d5d47f6-2650-4b16-8be4-8655273a3591', NULL, 0, 0, NULL, 1, 0, N'admin@ushop.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'43ab1741-65c5-46ce-8f47-861b7d3f1b31', N'guest@ushop.com', 0, N'AOEqXwQ5vIpgHx6ZOkBeeJw8wRukfHnb1xFifp/Kw+Nz2bF7uzRxew+LhIy/5LPHEw==', N'0cc2108d-7d6b-4370-a8f9-81472ed6936a', NULL, 0, 0, NULL, 1, 0, N'guest@ushop.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'756adf87-296e-4e48-acc7-80805671553c', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22ac6c9f-1526-4cce-9d2c-ae7e37390b36', N'756adf87-296e-4e48-acc7-80805671553c')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
