namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingGoals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goals", "AGoalName", c => c.String());
            AddColumn("dbo.Goals", "AGoalQuestion", c => c.String());
            AddColumn("dbo.Goals", "AGoalDays", c => c.String());
            AddColumn("dbo.Goals", "AGoal1", c => c.String());
            AddColumn("dbo.Goals", "AGoal2", c => c.String());
            AddColumn("dbo.Goals", "AGoal3", c => c.String());
            AddColumn("dbo.Goals", "AGoal4", c => c.String());
            AddColumn("dbo.Goals", "AGoal5", c => c.String());
            AddColumn("dbo.Goals", "AGoal6", c => c.String());
            AddColumn("dbo.Goals", "AGoal7", c => c.String());
            AddColumn("dbo.Goals", "AGoalDate1", c => c.DateTime());
            AddColumn("dbo.Goals", "AGoalDate2", c => c.DateTime());
            AddColumn("dbo.Goals", "AGoalDate3", c => c.DateTime());
            AddColumn("dbo.Goals", "AGoalDate4", c => c.DateTime());
            AddColumn("dbo.Goals", "AGoalDate5", c => c.DateTime());
            AddColumn("dbo.Goals", "AGoalDate6", c => c.DateTime());
            AddColumn("dbo.Goals", "AGoalDate7", c => c.DateTime());
            DropColumn("dbo.Goals", "GoalName");
            DropColumn("dbo.Goals", "GoalQuestion");
            DropColumn("dbo.Goals", "GoalDays");
            DropColumn("dbo.Goals", "Goal1");
            DropColumn("dbo.Goals", "Goal2");
            DropColumn("dbo.Goals", "Goal3");
            DropColumn("dbo.Goals", "Goal4");
            DropColumn("dbo.Goals", "Goal5");
            DropColumn("dbo.Goals", "Goal6");
            DropColumn("dbo.Goals", "Goal7");
            DropColumn("dbo.Goals", "GoalDate1");
            DropColumn("dbo.Goals", "GoalDate2");
            DropColumn("dbo.Goals", "GoalDate3");
            DropColumn("dbo.Goals", "GoalDate4");
            DropColumn("dbo.Goals", "GoalDate5");
            DropColumn("dbo.Goals", "GoalDate6");
            DropColumn("dbo.Goals", "GoalDate7");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Goals", "GoalDate7", c => c.DateTime());
            AddColumn("dbo.Goals", "GoalDate6", c => c.DateTime());
            AddColumn("dbo.Goals", "GoalDate5", c => c.DateTime());
            AddColumn("dbo.Goals", "GoalDate4", c => c.DateTime());
            AddColumn("dbo.Goals", "GoalDate3", c => c.DateTime());
            AddColumn("dbo.Goals", "GoalDate2", c => c.DateTime());
            AddColumn("dbo.Goals", "GoalDate1", c => c.DateTime());
            AddColumn("dbo.Goals", "Goal7", c => c.String());
            AddColumn("dbo.Goals", "Goal6", c => c.String());
            AddColumn("dbo.Goals", "Goal5", c => c.String());
            AddColumn("dbo.Goals", "Goal4", c => c.String());
            AddColumn("dbo.Goals", "Goal3", c => c.String());
            AddColumn("dbo.Goals", "Goal2", c => c.String());
            AddColumn("dbo.Goals", "Goal1", c => c.String());
            AddColumn("dbo.Goals", "GoalDays", c => c.String());
            AddColumn("dbo.Goals", "GoalQuestion", c => c.String());
            AddColumn("dbo.Goals", "GoalName", c => c.String());
            DropColumn("dbo.Goals", "AGoalDate7");
            DropColumn("dbo.Goals", "AGoalDate6");
            DropColumn("dbo.Goals", "AGoalDate5");
            DropColumn("dbo.Goals", "AGoalDate4");
            DropColumn("dbo.Goals", "AGoalDate3");
            DropColumn("dbo.Goals", "AGoalDate2");
            DropColumn("dbo.Goals", "AGoalDate1");
            DropColumn("dbo.Goals", "AGoal7");
            DropColumn("dbo.Goals", "AGoal6");
            DropColumn("dbo.Goals", "AGoal5");
            DropColumn("dbo.Goals", "AGoal4");
            DropColumn("dbo.Goals", "AGoal3");
            DropColumn("dbo.Goals", "AGoal2");
            DropColumn("dbo.Goals", "AGoal1");
            DropColumn("dbo.Goals", "AGoalDays");
            DropColumn("dbo.Goals", "AGoalQuestion");
            DropColumn("dbo.Goals", "AGoalName");
        }
    }
}
