namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGoalQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goals1", "GoalQuestion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goals1", "GoalQuestion");
        }
    }
}
