namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieGenreandProp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "MovieType_Id", c => c.Int());
            CreateIndex("dbo.Movies", "MovieType_Id");
            AddForeignKey("dbo.Movies", "MovieType_Id", "dbo.MovieGenres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieType_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieType_Id" });
            DropColumn("dbo.Movies", "MovieType_Id");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.MovieGenres");
        }
    }
}
