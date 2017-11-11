namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, NumberInStock, GenreId, ReleaseDate, DateAdded) VALUES ('The Terminator', 3, 8, 'Oct 26, 1984', 'Nov 11, 2017')");
            Sql("INSERT INTO Movies (Name, NumberInStock, GenreId, ReleaseDate, DateAdded) VALUES ('Terminator 2: Judgment Day', 5, 8, 'July 3, 1991', 'Nov 11, 2017')");
            Sql("INSERT INTO Movies (Name, NumberInStock, GenreId, ReleaseDate, DateAdded) VALUES ('Terminator 3: Rise of the Machines', 2, 8, 'July 2, 2003', 'Nov 11, 2017')");
            Sql("INSERT INTO Movies (Name, NumberInStock, GenreId, ReleaseDate, DateAdded) VALUES ('Shrek', 4, 2, 'April 22, 2001', 'Nov 11, 2017')");
        }
        
        public override void Down()
        {
        }
    }
}
