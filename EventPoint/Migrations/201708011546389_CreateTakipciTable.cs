namespace EventPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTakipciTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Takipcis",
                    c => new
                    {
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FolloweeId, t.FollowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId, cascadeDelete: false)
                .Index(t => new { t.FolloweeId, t.FollowerId }, unique: true, name: "AK_Takipci");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Takipcis", "AK_Takipcis");
            DropPrimaryKey("dbo.Takipcis");
            AddPrimaryKey("dbo.Takipcis", new[] { "FollowerId", "FolloweeId" });
            CreateIndex("dbo.Takipcis", "FolloweeId");
            CreateIndex("dbo.Takipcis", "FollowerId");
            RenameTable(name: "dbo.Takipcis", newName: "Followings");
        }
    }
}
