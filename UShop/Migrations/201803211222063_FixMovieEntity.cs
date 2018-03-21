namespace UShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMovieEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genre");
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Genre", c => c.String());
        }
    }
}
