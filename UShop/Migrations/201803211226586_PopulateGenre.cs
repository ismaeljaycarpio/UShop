namespace UShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES('Comedy')");
            Sql("INSERT INTO Genres VALUES('Horror')");
            Sql("INSERT INTO Genres VALUES('Romance')");
            Sql("INSERT INTO Genres VALUES('Drama')");
            Sql("INSERT INTO Genres VALUES('KPop')");
        }
        
        public override void Down()
        {
        }
    }
}
