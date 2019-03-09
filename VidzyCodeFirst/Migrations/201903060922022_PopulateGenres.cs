namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Genre_1'),('Genre_2'),('Genre_3')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres Where Name = 'Genre_1' OR 'Genre_2' OR 'Genre_3'");
        }
    }
}
