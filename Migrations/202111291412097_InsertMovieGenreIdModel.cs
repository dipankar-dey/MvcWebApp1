namespace MyFirstMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMovieGenreIdModel : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES(1,'Hangover',1,'1/1/2010','1/2/2010',1) ");
            Sql("insert into Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES(2,'Die Hard',2,'2/1/2010','2/2/2010',2) ");
            Sql("insert into Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES(3,'The Terminator',3,'3/1/2010','3/2/2010',3) ");
            Sql("insert into Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES(4,'Toy Story',4,'4/1/2010','4/2/2010',4) ");
            Sql("insert into Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES(5,'Titanic',5,'5/1/2010','5/2/2010',5) ");
        }
        
        public override void Down()
        {
        }
    }
}
