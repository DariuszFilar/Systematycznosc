namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Relationship1 = c.String(),
                        Relationship2 = c.String(),
                        Relationship3 = c.String(),
                        Relationship4 = c.String(),
                        Relationship5 = c.String(),
                        Relationship6 = c.String(),
                        Relationship7 = c.String(),
                        Relationship8 = c.String(),
                        Relationship9 = c.String(),
                        Relationship10 = c.String(),
                        Relationship11 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relationships", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Relationships", new[] { "Id" });
            DropTable("dbo.Relationships");
        }
    }
}
