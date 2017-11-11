namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Mystery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7,'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8,'Sci-Fi')");
        }
        
        public override void Down()
        {
        }
    }
}
