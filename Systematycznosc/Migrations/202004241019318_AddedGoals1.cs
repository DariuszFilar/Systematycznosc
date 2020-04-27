namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGoals1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goals1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GoalName = c.String(),
                        GoalDays = c.String(),
                        Goal1 = c.String(),
                        Goal2 = c.String(),
                        Goal3 = c.String(),
                        Goal4 = c.String(),
                        Goal5 = c.String(),
                        Goal6 = c.String(),
                        Goal7 = c.String(),
                        GoalDate1 = c.DateTime(),
                        GoalDate2 = c.DateTime(),
                        GoalDate3 = c.DateTime(),
                        GoalDate4 = c.DateTime(),
                        GoalDate5 = c.DateTime(),
                        GoalDate6 = c.DateTime(),
                        GoalDate7 = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goals1", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Goals1", new[] { "Id" });
            DropTable("dbo.Goals1");
        }
    }
}
