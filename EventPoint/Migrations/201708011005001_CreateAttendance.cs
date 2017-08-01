namespace EventPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EventId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId)
                .Index(t => new { t.EventId, t.AttendeeId }, unique: true, name: "AK_Attendance");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "EventId", "dbo.Events");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", "AK_Attendance");
            DropTable("dbo.Attendances");
        }
    }
}
