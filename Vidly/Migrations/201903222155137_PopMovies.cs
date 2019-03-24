namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, InStock, Genreid) VALUES ('Shrek', '2005-12-12 12:12:12', '2005-12-12 12:12:12', 4, 5)");
            
        }
        
        public override void Down()
        {
        }
    }
}
