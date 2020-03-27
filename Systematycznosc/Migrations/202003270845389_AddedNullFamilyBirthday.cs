namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullFamilyBirthday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday1", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday2", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday3", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday4", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday5", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday6", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday7", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday8", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday9", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday10", c => c.DateTime());
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday11", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday11", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday10", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday9", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday8", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday7", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday6", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday5", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday4", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday3", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyBirthdays", "FamilyBirthday1", c => c.DateTime(nullable: false));
        }
    }
}
