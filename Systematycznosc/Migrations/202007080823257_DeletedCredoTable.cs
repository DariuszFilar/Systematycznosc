namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedCredoTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Credoes", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Credoes", new[] { "Id" });
            DropTable("dbo.Credoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Credoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Credo1 = c.String(),
                        Credo2 = c.String(),
                        Credo3 = c.String(),
                        Credo4 = c.String(),
                        Credo5 = c.String(),
                        Credo6 = c.String(),
                        Credo7 = c.String(),
                        Credo8 = c.String(),
                        Credo9 = c.String(),
                        Credo10 = c.String(),
                        Credo11 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Credoes", "Id");
            AddForeignKey("dbo.Credoes", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
