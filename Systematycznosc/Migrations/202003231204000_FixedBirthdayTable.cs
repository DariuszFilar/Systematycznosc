namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedBirthdayTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName1", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName2", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName3", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName4", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName5", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName6", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName7", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName8", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName9", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName10", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName11", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName1", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName2", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName3", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName4", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName5", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName6", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName7", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName8", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName9", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName10", c => c.String());
            AddColumn("dbo.FriendsBirthdays", "FriendsBirthdayName11", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName11");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName10");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName9");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName8");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName7");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName6");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName5");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName4");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName3");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName2");
            DropColumn("dbo.FriendsBirthdays", "FriendsBirthdayName1");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName11");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName10");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName9");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName8");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName7");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName6");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName5");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName4");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName3");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName2");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName1");
        }
    }
}
