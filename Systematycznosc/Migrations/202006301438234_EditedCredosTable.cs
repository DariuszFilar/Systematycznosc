namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedCredosTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Credos", "CredoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credos", "CredoId", c => c.String());
        }
    }
}
