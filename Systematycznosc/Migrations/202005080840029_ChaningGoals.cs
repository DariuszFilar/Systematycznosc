namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChaningGoals : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Goals1", newName: "Goals");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Goals", newName: "Goals1");
        }
    }
}
