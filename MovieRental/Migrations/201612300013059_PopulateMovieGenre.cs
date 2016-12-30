namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MovieGenres ( Genre) Values ('Action')");
            Sql("Insert into MovieGenres ( Genre) Values ('Comedy')");
            Sql("Insert into MovieGenres ( Genre) Values ('Family')");
            Sql("Insert into MovieGenres ( Genre) Values ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
