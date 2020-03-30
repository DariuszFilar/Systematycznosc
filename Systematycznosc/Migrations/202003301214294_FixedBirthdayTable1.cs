namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedBirthdayTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday1", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday2", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday3", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday4", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday5", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday6", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday7", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday8", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday9", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday10", c => c.DateTime());
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday11", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday1", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday2", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday3", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday4", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday5", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday6", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday7", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday8", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday9", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday10", c => c.DateTime());
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday11", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday11", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday10", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday9", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday8", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday7", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday6", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday5", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday4", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday3", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OthersBirthdays", "OthersBirthday1", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday11", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday10", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday9", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday8", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday7", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday6", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday5", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday4", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday3", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FriendsBirthdays", "FriendsBirthday1", c => c.DateTime(nullable: false));
        }
    }
}
