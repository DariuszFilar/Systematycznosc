namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnotherGoals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EightGoals",
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
                "dbo.FifthGoals",
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
                "dbo.FourthGoals",
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
                "dbo.SeventhGoals",
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
                "dbo.SixthGoals",
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
                "dbo.ThirdGoals",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThirdGoals", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.SixthGoals", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.SeventhGoals", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FourthGoals", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FifthGoals", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.EightGoals", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.ThirdGoals", new[] { "UserProfileId" });
            DropIndex("dbo.SixthGoals", new[] { "UserProfileId" });
            DropIndex("dbo.SeventhGoals", new[] { "UserProfileId" });
            DropIndex("dbo.FourthGoals", new[] { "UserProfileId" });
            DropIndex("dbo.FifthGoals", new[] { "UserProfileId" });
            DropIndex("dbo.EightGoals", new[] { "UserProfileId" });
            DropTable("dbo.ThirdGoals");
            DropTable("dbo.SixthGoals");
            DropTable("dbo.SeventhGoals");
            DropTable("dbo.FourthGoals");
            DropTable("dbo.FifthGoals");
            DropTable("dbo.EightGoals");
        }
    }
}
