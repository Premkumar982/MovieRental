namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieGenreandProp1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieType_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieType_Id" });
            RenameColumn(table: "dbo.Movies", name: "MovieType_Id", newName: "MovieTypeId");
            AlterColumn("dbo.Movies", "MovieTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieTypeId");
            AddForeignKey("dbo.Movies", "MovieTypeId", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieTypeId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieTypeId" });
            AlterColumn("dbo.Movies", "MovieTypeId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "MovieTypeId", newName: "MovieType_Id");
            CreateIndex("dbo.Movies", "MovieType_Id");
            AddForeignKey("dbo.Movies", "MovieType_Id", "dbo.MovieGenres", "Id");
        }
    }
}
