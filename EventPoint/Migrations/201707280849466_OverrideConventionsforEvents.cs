namespace EventPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsforEvents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "ArtistId" });
            AlterColumn("dbo.Events", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Events", "ArtistId");
            AddForeignKey("dbo.Events", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "ArtistId" });
            AlterColumn("dbo.Events", "ArtistId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "ArtistId");
            AddForeignKey("dbo.Events", "ArtistId", "dbo.AspNetUsers", "Id");
        }
    }
}
