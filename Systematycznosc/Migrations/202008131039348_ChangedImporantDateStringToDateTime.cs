namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedImporantDateStringToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImportantEvents", "ImportantEventDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImportantEvents", "ImportantEventDate", c => c.String());
        }
    }
}
