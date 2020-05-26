namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTodoDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "TodoDate1", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName1", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate2", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName2", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate3", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName3", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate4", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName4", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate5", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName5", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate6", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName6", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate7", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName7", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate8", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName8", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate9", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName9", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate10", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName10", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate11", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName11", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "TodoDateName11");
            DropColumn("dbo.Todoes", "TodoDate11");
            DropColumn("dbo.Todoes", "TodoDateName10");
            DropColumn("dbo.Todoes", "TodoDate10");
            DropColumn("dbo.Todoes", "TodoDateName9");
            DropColumn("dbo.Todoes", "TodoDate9");
            DropColumn("dbo.Todoes", "TodoDateName8");
            DropColumn("dbo.Todoes", "TodoDate8");
            DropColumn("dbo.Todoes", "TodoDateName7");
            DropColumn("dbo.Todoes", "TodoDate7");
            DropColumn("dbo.Todoes", "TodoDateName6");
            DropColumn("dbo.Todoes", "TodoDate6");
            DropColumn("dbo.Todoes", "TodoDateName5");
            DropColumn("dbo.Todoes", "TodoDate5");
            DropColumn("dbo.Todoes", "TodoDateName4");
            DropColumn("dbo.Todoes", "TodoDate4");
            DropColumn("dbo.Todoes", "TodoDateName3");
            DropColumn("dbo.Todoes", "TodoDate3");
            DropColumn("dbo.Todoes", "TodoDateName2");
            DropColumn("dbo.Todoes", "TodoDate2");
            DropColumn("dbo.Todoes", "TodoDateName1");
            DropColumn("dbo.Todoes", "TodoDate1");
        }
    }
}
