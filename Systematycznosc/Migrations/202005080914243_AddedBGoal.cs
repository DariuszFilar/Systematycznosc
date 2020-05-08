namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBGoal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goals", "BGoalName", c => c.String());
            AddColumn("dbo.Goals", "BGoalQuestion", c => c.String());
            AddColumn("dbo.Goals", "BGoalDays", c => c.String());
            AddColumn("dbo.Goals", "BGoal1", c => c.String());
            AddColumn("dbo.Goals", "BGoal2", c => c.String());
            AddColumn("dbo.Goals", "BGoal3", c => c.String());
            AddColumn("dbo.Goals", "BGoal4", c => c.String());
            AddColumn("dbo.Goals", "BGoal5", c => c.String());
            AddColumn("dbo.Goals", "BGoal6", c => c.String());
            AddColumn("dbo.Goals", "BGoal7", c => c.String());
            AddColumn("dbo.Goals", "BGoalDate1", c => c.DateTime());
            AddColumn("dbo.Goals", "BGoalDate2", c => c.DateTime());
            AddColumn("dbo.Goals", "BGoalDate3", c => c.DateTime());
            AddColumn("dbo.Goals", "BGoalDate4", c => c.DateTime());
            AddColumn("dbo.Goals", "BGoalDate5", c => c.DateTime());
            AddColumn("dbo.Goals", "BGoalDate6", c => c.DateTime());
            AddColumn("dbo.Goals", "BGoalDate7", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goals", "BGoalDate7");
            DropColumn("dbo.Goals", "BGoalDate6");
            DropColumn("dbo.Goals", "BGoalDate5");
            DropColumn("dbo.Goals", "BGoalDate4");
            DropColumn("dbo.Goals", "BGoalDate3");
            DropColumn("dbo.Goals", "BGoalDate2");
            DropColumn("dbo.Goals", "BGoalDate1");
            DropColumn("dbo.Goals", "BGoal7");
            DropColumn("dbo.Goals", "BGoal6");
            DropColumn("dbo.Goals", "BGoal5");
            DropColumn("dbo.Goals", "BGoal4");
            DropColumn("dbo.Goals", "BGoal3");
            DropColumn("dbo.Goals", "BGoal2");
            DropColumn("dbo.Goals", "BGoal1");
            DropColumn("dbo.Goals", "BGoalDays");
            DropColumn("dbo.Goals", "BGoalQuestion");
            DropColumn("dbo.Goals", "BGoalName");
        }
    }
}
