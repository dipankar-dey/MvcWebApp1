namespace MyFirstMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMovieEntry : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Movies (Id,Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(1,'Hangover','Comedy','1/1/2010','1/2/2010',1) ");
            Sql("insert into Movies (Id,Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(2,'Die Hard','Action','2/1/2010','2/2/2010',2) ");
            Sql("insert into Movies (Id,Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(3,'The Terminator','Action','3/1/2010','3/2/2010',3) ");
            Sql("insert into Movies (Id,Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(4,'Toy Story','Family','4/1/2010','4/2/2010',4) ");
            Sql("insert into Movies (Id,Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(5,'Titanic','Romance','5/1/2010','5/2/2010',5) ");
        }
        
        public override void Down()
        {
        }
    }
}
