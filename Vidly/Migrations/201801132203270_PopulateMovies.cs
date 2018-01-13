namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) " +
                "VALUES ('Hangover',2009/11/03,2017/12/12, 5, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
