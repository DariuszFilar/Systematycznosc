namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTodoTableAndAddedImporantEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportantEvents",
                c => new
                    {
                        ImportantEventId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        ImportantEventName = c.String(),
                        ImportantEventDate = c.String(),
                    })
                .PrimaryKey(t => new { t.ImportantEventId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImportantEvents", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.ImportantEvents", new[] { "UserProfileId" });
            DropTable("dbo.ImportantEvents");
        }
    }
}
