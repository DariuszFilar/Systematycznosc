namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthday : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyBirthdays",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FamilyBirthday1 = c.DateTime(nullable: false),
                        FamilyBirthday2 = c.DateTime(nullable: false),
                        FamilyBirthday3 = c.DateTime(nullable: false),
                        FamilyBirthday4 = c.DateTime(nullable: false),
                        FamilyBirthday5 = c.DateTime(nullable: false),
                        FamilyBirthday6 = c.DateTime(nullable: false),
                        FamilyBirthday7 = c.DateTime(nullable: false),
                        FamilyBirthday8 = c.DateTime(nullable: false),
                        FamilyBirthday9 = c.DateTime(nullable: false),
                        FamilyBirthday10 = c.DateTime(nullable: false),
                        FamilyBirthday11 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FriendsBirthdays",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FriendsBirthday1 = c.DateTime(nullable: false),
                        FriendsBirthday2 = c.DateTime(nullable: false),
                        FriendsBirthday3 = c.DateTime(nullable: false),
                        FriendsBirthday4 = c.DateTime(nullable: false),
                        FriendsBirthday5 = c.DateTime(nullable: false),
                        FriendsBirthday6 = c.DateTime(nullable: false),
                        FriendsBirthday7 = c.DateTime(nullable: false),
                        FriendsBirthday8 = c.DateTime(nullable: false),
                        FriendsBirthday9 = c.DateTime(nullable: false),
                        FriendsBirthday10 = c.DateTime(nullable: false),
                        FriendsBirthday11 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.OthersBirthdays",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OthersBirthday1 = c.DateTime(nullable: false),
                        OthersBirthday2 = c.DateTime(nullable: false),
                        OthersBirthday3 = c.DateTime(nullable: false),
                        OthersBirthday4 = c.DateTime(nullable: false),
                        OthersBirthday5 = c.DateTime(nullable: false),
                        OthersBirthday6 = c.DateTime(nullable: false),
                        OthersBirthday7 = c.DateTime(nullable: false),
                        OthersBirthday8 = c.DateTime(nullable: false),
                        OthersBirthday9 = c.DateTime(nullable: false),
                        OthersBirthday10 = c.DateTime(nullable: false),
                        OthersBirthday11 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OthersBirthdays", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendsBirthdays", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FamilyBirthdays", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.OthersBirthdays", new[] { "Id" });
            DropIndex("dbo.FriendsBirthdays", new[] { "Id" });
            DropIndex("dbo.FamilyBirthdays", new[] { "Id" });
            DropTable("dbo.OthersBirthdays");
            DropTable("dbo.FriendsBirthdays");
            DropTable("dbo.FamilyBirthdays");
        }
    }
}
