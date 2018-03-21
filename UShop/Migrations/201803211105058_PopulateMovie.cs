namespace UShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 1', 1/1/1910, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 2', 1/1/1920, 1/2/1900, 1, 'Comedy')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 3', 1/1/1930, 1/2/1900, 1, 'Romance')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 4', 1/1/1940, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 5', 1/1/1950, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 6', 1/1/1960, 1/2/1900, 1, 'Romance')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 7', 1/1/1970, 1/2/1900, 1, 'Comedy')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 8', 1/1/1980, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 9', 1/1/1990, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 10', 1/1/1920, 1/2/1900, 1, 'Romance')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 11', 1/1/1901, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 12', 1/1/1902, 1/2/1900, 1, 'Comedy')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 13', 1/1/1903, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 14', 1/1/1904, 1/2/1900, 1, 'Horror')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 15', 1/1/1905, 1/2/1900, 1, 'Comedy')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 16', 1/1/1906, 1/2/1900, 1, 'Romance')");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,Genre) VALUES('Jumanji 17', 1/1/1907, 1/2/1900, 1, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
