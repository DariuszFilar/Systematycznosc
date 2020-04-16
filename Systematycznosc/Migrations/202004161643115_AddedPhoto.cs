namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Photo");
        }
    }
}
