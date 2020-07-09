namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCredosTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credos",
                c => new
                    {
                        CredosId = c.String(nullable: false, maxLength: 128),
                        CredoId = c.String(),
                        Credo1 = c.String(),
                        Credo2 = c.String(),
                        Credo3 = c.String(),
                        Credo4 = c.String(),
                        Credo5 = c.String(),
                        Credo6 = c.String(),
                        Credo7 = c.String(),
                        Credo8 = c.String(),
                        Credo9 = c.String(),
                        Credo10 = c.String(),
                        Credo11 = c.String(),
                        UserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CredosId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credos", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.Credos", new[] { "UserProfile_Id" });
            DropTable("dbo.Credos");
        }
    }
}
