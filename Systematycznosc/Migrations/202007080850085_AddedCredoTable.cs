namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCredoTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Credos", "UserProfile_Id", "dbo.UserProfiles");
            RenameTable(name: "dbo.Credos", newName: "Credoes");
            DropIndex("dbo.Credoes", new[] { "UserProfile_Id" });
            RenameColumn(table: "dbo.Credoes", name: "UserProfile_Id", newName: "UserProfileId");
            DropPrimaryKey("dbo.Credoes");
            AddColumn("dbo.Credoes", "CredoId", c => c.Int(nullable: false));
            AddColumn("dbo.Credoes", "CredoValue", c => c.String());
            AlterColumn("dbo.Credoes", "UserProfileId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Credoes", new[] { "CredoId", "UserProfileId" });
            CreateIndex("dbo.Credoes", "UserProfileId");
            AddForeignKey("dbo.Credoes", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            DropColumn("dbo.Credoes", "CredosId");
            DropColumn("dbo.Credoes", "Credo1");
            DropColumn("dbo.Credoes", "Credo2");
            DropColumn("dbo.Credoes", "Credo3");
            DropColumn("dbo.Credoes", "Credo4");
            DropColumn("dbo.Credoes", "Credo5");
            DropColumn("dbo.Credoes", "Credo6");
            DropColumn("dbo.Credoes", "Credo7");
            DropColumn("dbo.Credoes", "Credo8");
            DropColumn("dbo.Credoes", "Credo9");
            DropColumn("dbo.Credoes", "Credo10");
            DropColumn("dbo.Credoes", "Credo11");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credoes", "Credo11", c => c.String());
            AddColumn("dbo.Credoes", "Credo10", c => c.String());
            AddColumn("dbo.Credoes", "Credo9", c => c.String());
            AddColumn("dbo.Credoes", "Credo8", c => c.String());
            AddColumn("dbo.Credoes", "Credo7", c => c.String());
            AddColumn("dbo.Credoes", "Credo6", c => c.String());
            AddColumn("dbo.Credoes", "Credo5", c => c.String());
            AddColumn("dbo.Credoes", "Credo4", c => c.String());
            AddColumn("dbo.Credoes", "Credo3", c => c.String());
            AddColumn("dbo.Credoes", "Credo2", c => c.String());
            AddColumn("dbo.Credoes", "Credo1", c => c.String());
            AddColumn("dbo.Credoes", "CredosId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Credoes", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Credoes", new[] { "UserProfileId" });
            DropPrimaryKey("dbo.Credoes");
            AlterColumn("dbo.Credoes", "UserProfileId", c => c.String(maxLength: 128));
            DropColumn("dbo.Credoes", "CredoValue");
            DropColumn("dbo.Credoes", "CredoId");
            AddPrimaryKey("dbo.Credoes", "CredosId");
            RenameColumn(table: "dbo.Credoes", name: "UserProfileId", newName: "UserProfile_Id");
            CreateIndex("dbo.Credoes", "UserProfile_Id");
            AddForeignKey("dbo.Credos", "UserProfile_Id", "dbo.UserProfiles", "Id");
            RenameTable(name: "dbo.Credoes", newName: "Credos");
        }
    }
}
