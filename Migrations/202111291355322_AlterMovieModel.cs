namespace MyFirstMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
