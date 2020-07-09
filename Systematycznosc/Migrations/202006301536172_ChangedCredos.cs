namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCredos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Credos", "Credos_CredosId", "dbo.Credos");
            DropIndex("dbo.Credos", new[] { "Credos_CredosId" });
            DropColumn("dbo.Credos", "Credos_CredosId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credos", "Credos_CredosId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Credos", "Credos_CredosId");
            AddForeignKey("dbo.Credos", "Credos_CredosId", "dbo.Credos", "CredosId");
        }
    }
}
