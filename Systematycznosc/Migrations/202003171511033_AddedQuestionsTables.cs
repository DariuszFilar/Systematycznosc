namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuestionsTables : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MorningQuestions", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EveningQuestions", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.MorningQuestions", new[] { "Id" });
            DropIndex("dbo.EveningQuestions", new[] { "Id" });
            DropTable("dbo.MorningQuestions");
            DropTable("dbo.EveningQuestions");
        }
    }
}
