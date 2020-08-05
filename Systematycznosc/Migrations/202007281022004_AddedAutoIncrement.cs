namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAutoIncrement : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Credoes");
            AlterColumn("dbo.Credoes", "CredoId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Credoes", new[] { "CredoId", "UserProfileId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Credoes");
            AlterColumn("dbo.Credoes", "CredoId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Credoes", new[] { "CredoId", "UserProfileId" });
        }
    }
}
