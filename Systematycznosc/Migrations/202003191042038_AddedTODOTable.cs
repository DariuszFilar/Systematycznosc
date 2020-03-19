namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTODOTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TODOes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TODO1 = c.String(),
                        TODO2 = c.String(),
                        TODO3 = c.String(),
                        TODO4 = c.String(),
                        TODO5 = c.String(),
                        TODO6 = c.String(),
                        TODO7 = c.String(),
                        TODO8 = c.String(),
                        TODO9 = c.String(),
                        TODO10 = c.String(),
                        TODO11 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TODOes", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.TODOes", new[] { "Id" });
            DropTable("dbo.TODOes");
        }
    }
}
