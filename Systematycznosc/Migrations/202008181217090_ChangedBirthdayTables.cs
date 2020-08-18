namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBirthdayTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FamilyBirthdays", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendsBirthdays", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OthersBirthdays", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.FamilyBirthdays", new[] { "Id" });
            DropIndex("dbo.FriendsBirthdays", new[] { "Id" });
            DropIndex("dbo.OthersBirthdays", new[] { "Id" });
            DropPrimaryKey("dbo.FamilyBirthdays");
            CreateTable(
                "dbo.FriendBirthdays",
                c => new
                    {
                        FriendBirthdayEventId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        FriendBirthdayName = c.String(),
                        FriendBirthdayDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.FriendBirthdayEventId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.OtherBirthdays",
                c => new
                    {
                        OtherBirthdayEventId = c.Int(nullable: false),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        OtherBirthdayName = c.String(),
                        OtherBirthdayDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.OtherBirthdayEventId, t.UserProfileId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayEventId", c => c.Int(nullable: false));
            AddColumn("dbo.FamilyBirthdays", "UserProfileId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayDate", c => c.DateTime());
            AddPrimaryKey("dbo.FamilyBirthdays", new[] { "FamilyBirthdayEventId", "UserProfileId" });
            CreateIndex("dbo.FamilyBirthdays", "UserProfileId");
            AddForeignKey("dbo.FamilyBirthdays", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            DropColumn("dbo.FamilyBirthdays", "Id");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday1");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName1");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday2");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName2");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday3");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName3");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday4");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName4");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday5");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName5");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday6");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName6");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday7");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName7");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday8");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName8");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday9");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName9");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday10");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName10");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthday11");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName11");
            DropTable("dbo.FriendsBirthdays");
            DropTable("dbo.OthersBirthdays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OthersBirthdays",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OthersBirthday1 = c.DateTime(),
                        OthersBirthdayName1 = c.String(),
                        OthersBirthday2 = c.DateTime(),
                        OthersBirthdayName2 = c.String(),
                        OthersBirthday3 = c.DateTime(),
                        OthersBirthdayName3 = c.String(),
                        OthersBirthday4 = c.DateTime(),
                        OthersBirthdayName4 = c.String(),
                        OthersBirthday5 = c.DateTime(),
                        OthersBirthdayName5 = c.String(),
                        OthersBirthday6 = c.DateTime(),
                        OthersBirthdayName6 = c.String(),
                        OthersBirthday7 = c.DateTime(),
                        OthersBirthdayName7 = c.String(),
                        OthersBirthday8 = c.DateTime(),
                        OthersBirthdayName8 = c.String(),
                        OthersBirthday9 = c.DateTime(),
                        OthersBirthdayName9 = c.String(),
                        OthersBirthday10 = c.DateTime(),
                        OthersBirthdayName10 = c.String(),
                        OthersBirthday11 = c.DateTime(),
                        OthersBirthdayName11 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FriendsBirthdays",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FriendsBirthday1 = c.DateTime(),
                        FriendsBirthdayName1 = c.String(),
                        FriendsBirthday2 = c.DateTime(),
                        FriendsBirthdayName2 = c.String(),
                        FriendsBirthday3 = c.DateTime(),
                        FriendsBirthdayName3 = c.String(),
                        FriendsBirthday4 = c.DateTime(),
                        FriendsBirthdayName4 = c.String(),
                        FriendsBirthday5 = c.DateTime(),
                        FriendsBirthdayName5 = c.String(),
                        FriendsBirthday6 = c.DateTime(),
                        FriendsBirthdayName6 = c.String(),
                        FriendsBirthday7 = c.DateTime(),
                        FriendsBirthdayName7 = c.String(),
                        FriendsBirthday8 = c.DateTime(),
                        FriendsBirthdayName8 = c.String(),
                        FriendsBirthday9 = c.DateTime(),
                        FriendsBirthdayName9 = c.String(),
                        FriendsBirthday10 = c.DateTime(),
                        FriendsBirthdayName10 = c.String(),
                        FriendsBirthday11 = c.DateTime(),
                        FriendsBirthdayName11 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName11", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday11", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName10", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday10", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName9", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday9", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName8", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday8", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName7", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday7", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName6", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday6", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName5", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday5", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName4", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday4", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName3", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday3", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName2", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday2", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthdayName1", c => c.String());
            AddColumn("dbo.FamilyBirthdays", "FamilyBirthday1", c => c.DateTime());
            AddColumn("dbo.FamilyBirthdays", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.OtherBirthdays", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FriendBirthdays", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FamilyBirthdays", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.OtherBirthdays", new[] { "UserProfileId" });
            DropIndex("dbo.FriendBirthdays", new[] { "UserProfileId" });
            DropIndex("dbo.FamilyBirthdays", new[] { "UserProfileId" });
            DropPrimaryKey("dbo.FamilyBirthdays");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayDate");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayName");
            DropColumn("dbo.FamilyBirthdays", "UserProfileId");
            DropColumn("dbo.FamilyBirthdays", "FamilyBirthdayEventId");
            DropTable("dbo.OtherBirthdays");
            DropTable("dbo.FriendBirthdays");
            AddPrimaryKey("dbo.FamilyBirthdays", "Id");
            CreateIndex("dbo.OthersBirthdays", "Id");
            CreateIndex("dbo.FriendsBirthdays", "Id");
            CreateIndex("dbo.FamilyBirthdays", "Id");
            AddForeignKey("dbo.OthersBirthdays", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendsBirthdays", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FamilyBirthdays", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
