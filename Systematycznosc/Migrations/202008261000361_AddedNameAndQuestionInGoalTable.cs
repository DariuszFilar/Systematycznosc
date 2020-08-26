namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameAndQuestionInGoalTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Goals", newName: "Goals2");
            DropForeignKey("dbo.Goals1", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Goals1", new[] { "UserProfileId" });
            CreateTable(
                "dbo.FirstGoals",
                c => new
                    {
                        GoalId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        GoalName = c.String(),
                        GoalQuestion = c.String(),
                        GoalStatus = c.String(),
                        GoalDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.GoalId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.SecondGoals",
                c => new
                    {
                        GoalId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        GoalName = c.String(),
                        GoalQuestion = c.String(),
                        GoalStatus = c.String(),
                        GoalDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.GoalId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            DropTable("dbo.Goals1");
        }
        
        public override void Down()
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
                .PrimaryKey(t => new { t.GoalId, t.UserProfileId });
            
            DropForeignKey("dbo.SecondGoals", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FirstGoals", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.SecondGoals", new[] { "UserProfileId" });
            DropIndex("dbo.FirstGoals", new[] { "UserProfileId" });
            DropTable("dbo.SecondGoals");
            DropTable("dbo.FirstGoals");
            CreateIndex("dbo.Goals1", "UserProfileId");
            AddForeignKey("dbo.Goals1", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Goals2", newName: "Goals");
        }
    }
}
