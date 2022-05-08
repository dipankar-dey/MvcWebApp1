namespace MyFirstMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from Movies");
        }
        
        public override void Down()
        {
        }
    }
}
