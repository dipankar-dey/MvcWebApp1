namespace MyFirstMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieGenreIdModel : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from dbo.Movies");
        }
        
        public override void Down()
        {
        }
    }
}
