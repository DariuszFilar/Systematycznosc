namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedEveninTableToEvening : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EveningQuestions", "EveningQuestionValue", c => c.String());
            DropColumn("dbo.EveningQuestions", "EveninQuestionValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EveningQuestions", "EveninQuestionValue", c => c.String());
            DropColumn("dbo.EveningQuestions", "EveningQuestionValue");
        }
    }
}
