namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGoalTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goals1",
                c => new
                    {
                        GoalId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        FirstGoalStatus = c.String(),
                        FirstGoalDate = c.DateTime(),
                        SecondGoalStatus = c.String(),
                        SecondGoalDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.GoalId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goals1", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Goals1", new[] { "UserProfileId" });
            DropTable("dbo.Goals1");
        }
    }
}
