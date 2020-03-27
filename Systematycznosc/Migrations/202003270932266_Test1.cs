namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday1", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday1", c => c.DateTime(nullable: false));
        }
    }
}
