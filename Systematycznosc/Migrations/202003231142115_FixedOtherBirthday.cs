namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedOtherBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName1", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName2", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName3", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName4", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName5", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName6", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName7", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName8", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName9", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName10", c => c.String());
            AddColumn("dbo.OthersBirthdays", "OthersBirthdayName11", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName11");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName10");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName9");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName8");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName7");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName6");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName5");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName4");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName3");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName2");
            DropColumn("dbo.OthersBirthdays", "OthersBirthdayName1");
        }
    }
}
