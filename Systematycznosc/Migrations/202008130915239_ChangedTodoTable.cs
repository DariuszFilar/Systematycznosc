namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTodoTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Todoes", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "Id" });
            DropPrimaryKey("dbo.Todoes");
            AddColumn("dbo.AspNetUsers", "Todo_TodoId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Todo_UserProfileId", c => c.String(maxLength: 128));
            AddColumn("dbo.Todoes", "TodoId", c => c.Int(nullable: false));
            AddColumn("dbo.Todoes", "UserProfileId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Todoes", "TodoValue", c => c.String());
            AddPrimaryKey("dbo.Todoes", new[] { "TodoId", "UserProfileId" });
            CreateIndex("dbo.Todoes", "UserProfileId");
            CreateIndex("dbo.AspNetUsers", new[] { "Todo_TodoId", "Todo_UserProfileId" });
            AddForeignKey("dbo.Todoes", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", new[] { "Todo_TodoId", "Todo_UserProfileId" }, "dbo.Todoes", new[] { "TodoId", "UserProfileId" });
            DropColumn("dbo.Todoes", "Id");
            DropColumn("dbo.Todoes", "Todo1");
            DropColumn("dbo.Todoes", "Todo2");
            DropColumn("dbo.Todoes", "Todo3");
            DropColumn("dbo.Todoes", "Todo4");
            DropColumn("dbo.Todoes", "Todo5");
            DropColumn("dbo.Todoes", "Todo6");
            DropColumn("dbo.Todoes", "Todo7");
            DropColumn("dbo.Todoes", "Todo8");
            DropColumn("dbo.Todoes", "Todo9");
            DropColumn("dbo.Todoes", "Todo10");
            DropColumn("dbo.Todoes", "Todo11");
            DropColumn("dbo.Todoes", "TodoDate1");
            DropColumn("dbo.Todoes", "TodoDateName1");
            DropColumn("dbo.Todoes", "TodoDate2");
            DropColumn("dbo.Todoes", "TodoDateName2");
            DropColumn("dbo.Todoes", "TodoDate3");
            DropColumn("dbo.Todoes", "TodoDateName3");
            DropColumn("dbo.Todoes", "TodoDate4");
            DropColumn("dbo.Todoes", "TodoDateName4");
            DropColumn("dbo.Todoes", "TodoDate5");
            DropColumn("dbo.Todoes", "TodoDateName5");
            DropColumn("dbo.Todoes", "TodoDate6");
            DropColumn("dbo.Todoes", "TodoDateName6");
            DropColumn("dbo.Todoes", "TodoDate7");
            DropColumn("dbo.Todoes", "TodoDateName7");
            DropColumn("dbo.Todoes", "TodoDate8");
            DropColumn("dbo.Todoes", "TodoDateName8");
            DropColumn("dbo.Todoes", "TodoDate9");
            DropColumn("dbo.Todoes", "TodoDateName9");
            DropColumn("dbo.Todoes", "TodoDate10");
            DropColumn("dbo.Todoes", "TodoDateName10");
            DropColumn("dbo.Todoes", "TodoDate11");
            DropColumn("dbo.Todoes", "TodoDateName11");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "TodoDateName11", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate11", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName10", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate10", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName9", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate9", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName8", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate8", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName7", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate7", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName6", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate6", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName5", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate5", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName4", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate4", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName3", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate3", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName2", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate2", c => c.DateTime());
            AddColumn("dbo.Todoes", "TodoDateName1", c => c.String());
            AddColumn("dbo.Todoes", "TodoDate1", c => c.DateTime());
            AddColumn("dbo.Todoes", "Todo11", c => c.String());
            AddColumn("dbo.Todoes", "Todo10", c => c.String());
            AddColumn("dbo.Todoes", "Todo9", c => c.String());
            AddColumn("dbo.Todoes", "Todo8", c => c.String());
            AddColumn("dbo.Todoes", "Todo7", c => c.String());
            AddColumn("dbo.Todoes", "Todo6", c => c.String());
            AddColumn("dbo.Todoes", "Todo5", c => c.String());
            AddColumn("dbo.Todoes", "Todo4", c => c.String());
            AddColumn("dbo.Todoes", "Todo3", c => c.String());
            AddColumn("dbo.Todoes", "Todo2", c => c.String());
            AddColumn("dbo.Todoes", "Todo1", c => c.String());
            AddColumn("dbo.Todoes", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", new[] { "Todo_TodoId", "Todo_UserProfileId" }, "dbo.Todoes");
            DropForeignKey("dbo.Todoes", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.AspNetUsers", new[] { "Todo_TodoId", "Todo_UserProfileId" });
            DropIndex("dbo.Todoes", new[] { "UserProfileId" });
            DropPrimaryKey("dbo.Todoes");
            DropColumn("dbo.Todoes", "TodoValue");
            DropColumn("dbo.Todoes", "UserProfileId");
            DropColumn("dbo.Todoes", "TodoId");
            DropColumn("dbo.AspNetUsers", "Todo_UserProfileId");
            DropColumn("dbo.AspNetUsers", "Todo_TodoId");
            AddPrimaryKey("dbo.Todoes", "Id");
            CreateIndex("dbo.Todoes", "Id");
            AddForeignKey("dbo.Todoes", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
