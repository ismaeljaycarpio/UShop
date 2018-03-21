namespace UShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesGenre : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreId = 1");
        }
        
        public override void Down()
        {
        }
    }
}
