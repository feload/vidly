namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PupulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1, 'Adventure')");
            Sql("INSERT INTO Genres VALUES (2, 'Action')");
            Sql("INSERT INTO Genres VALUES (3, 'Drama')");
            Sql("INSERT INTO Genres VALUES (4, 'Sci-Fi')");
        }
        
        public override void Down()
        {
        }
    }
}
