namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EveningQuestions");
            DropTable("dbo.MorningQuestions");
            DropForeignKey("dbo.EveningQuestions", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MorningQuestions", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" }, "dbo.Relationships");
            DropIndex("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" });
            DropIndex("dbo.EveningQuestions", new[] { "Id" });
            DropIndex("dbo.MorningQuestions", new[] { "Id" });
            CreateTable(
                "dbo.EveningQuestions",
                c => new
                    {
                        EveningQuestionId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        EveninQuestionValue = c.String(),
                    })
                .PrimaryKey(t => new { t.EveningQuestionId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.MorningQuestions",
                c => new
                    {
                        MorningQuestionId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        MorningQuestionValue = c.String(),
                    })
                .PrimaryKey(t => new { t.MorningQuestionId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            DropColumn("dbo.AspNetUsers", "Relationship_RelationshipId");
            DropColumn("dbo.AspNetUsers", "Relationship_UserProfileId");
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MorningQuestions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MorningQuestions1 = c.String(),
                        MorningQuestions2 = c.String(),
                        MorningQuestions3 = c.String(),
                        MorningQuestions4 = c.String(),
                        MorningQuestions5 = c.String(),
                        MorningQuestions6 = c.String(),
                        MorningQuestions7 = c.String(),
                        MorningQuestions8 = c.String(),
                        MorningQuestions9 = c.String(),
                        MorningQuestions10 = c.String(),
                        MorningQuestions11 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EveningQuestions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EveningQuestions1 = c.String(),
                        EveningQuestions2 = c.String(),
                        EveningQuestions3 = c.String(),
                        EveningQuestions4 = c.String(),
                        EveningQuestions5 = c.String(),
                        EveningQuestions6 = c.String(),
                        EveningQuestions7 = c.String(),
                        EveningQuestions8 = c.String(),
                        EveningQuestions9 = c.String(),
                        EveningQuestions10 = c.String(),
                        EveningQuestions11 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Relationship_UserProfileId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Relationship_RelationshipId", c => c.Int());
            DropForeignKey("dbo.MorningQuestions", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.EveningQuestions", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.MorningQuestions", new[] { "UserProfileId" });
            DropIndex("dbo.EveningQuestions", new[] { "UserProfileId" });
            DropTable("dbo.MorningQuestions");
            DropTable("dbo.EveningQuestions");
            CreateIndex("dbo.MorningQuestions", "Id");
            CreateIndex("dbo.EveningQuestions", "Id");
            CreateIndex("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" });
            AddForeignKey("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" }, "dbo.Relationships", new[] { "RelationshipId", "UserProfileId" });
            AddForeignKey("dbo.MorningQuestions", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EveningQuestions", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
