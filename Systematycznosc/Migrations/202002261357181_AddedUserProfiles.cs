namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Nickname = c.String(),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropTable("dbo.UserProfiles");
        }
    }
}
