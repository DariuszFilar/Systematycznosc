namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBirthdayEventIdToBirthdayId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FamilyBirthdays");
            DropPrimaryKey("dbo.FriendBirthdays");
            DropPrimaryKey("dbo.OtherBirthdays");
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayId", c => c.Int(nullable: false));
            AddColumn("dbo.FriendBirthdays", "FriendBirthdayId", c => c.Int(nullable: false));
            AddColumn("dbo.OtherBirthdays", "OtherBirthdayId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FamilyBirthdays", new[] { "FamilyBirthdayId", "UserProfileId" });
            AddPrimaryKey("dbo.FriendBirthdays", new[] { "FriendBirthdayId", "UserProfileId" });
            AddPrimaryKey("dbo.OtherBirthdays", new[] { "OtherBirthdayId", "UserProfileId" });
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayEventId");
            DropColumn("dbo.FriendBirthdays", "FriendBirthdayEventId");
            DropColumn("dbo.OtherBirthdays", "OtherBirthdayEventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OtherBirthdays", "OtherBirthdayEventId", c => c.Int(nullable: false));
            AddColumn("dbo.FriendBirthdays", "FriendBirthdayEventId", c => c.Int(nullable: false));
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayEventId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.OtherBirthdays");
            DropPrimaryKey("dbo.FriendBirthdays");
            DropPrimaryKey("dbo.FamilyBirthdays");
            DropColumn("dbo.OtherBirthdays", "OtherBirthdayId");
            DropColumn("dbo.FriendBirthdays", "FriendBirthdayId");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayId");
            AddPrimaryKey("dbo.OtherBirthdays", new[] { "OtherBirthdayEventId", "UserProfileId" });
            AddPrimaryKey("dbo.FriendBirthdays", new[] { "FriendBirthdayEventId", "UserProfileId" });
            AddPrimaryKey("dbo.FamilyBirthdays", new[] { "FamilyBirthdayEventId", "UserProfileId" });
        }
    }
}
