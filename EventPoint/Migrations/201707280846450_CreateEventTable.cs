namespace EventPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEventTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Events", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Events", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Events", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Events", name: "IX_Artist_Id", newName: "IX_ArtistId");
            AlterColumn("dbo.Events", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Events", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Events", "GenreId");
            AddForeignKey("dbo.Events", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "GenreId", "dbo.Genres");
            DropIndex("dbo.Events", new[] { "GenreId" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Events", "GenreId", c => c.Byte());
            AlterColumn("dbo.Events", "Venue", c => c.String());
            RenameIndex(table: "dbo.Events", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Events", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Events", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Events", "Genre_Id");
            AddForeignKey("dbo.Events", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
