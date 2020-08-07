namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRelationshipTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relationships", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Relationships", new[] { "Id" });
            DropPrimaryKey("dbo.Relationships");
            AddColumn("dbo.AspNetUsers", "Relationship_RelationshipId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Relationship_UserProfileId", c => c.String(maxLength: 128));
            AddColumn("dbo.Relationships", "RelationshipId", c => c.Int(nullable: false));
            AddColumn("dbo.Relationships", "UserProfileId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Relationships", "RelationshipValue", c => c.String());
            AddPrimaryKey("dbo.Relationships", new[] { "RelationshipId", "UserProfileId" });
            CreateIndex("dbo.Relationships", "UserProfileId");
            CreateIndex("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" });
            AddForeignKey("dbo.Relationships", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" }, "dbo.Relationships", new[] { "RelationshipId", "UserProfileId" });
            DropColumn("dbo.Relationships", "Id");
            DropColumn("dbo.Relationships", "Relationship1");
            DropColumn("dbo.Relationships", "Relationship2");
            DropColumn("dbo.Relationships", "Relationship3");
            DropColumn("dbo.Relationships", "Relationship4");
            DropColumn("dbo.Relationships", "Relationship5");
            DropColumn("dbo.Relationships", "Relationship6");
            DropColumn("dbo.Relationships", "Relationship7");
            DropColumn("dbo.Relationships", "Relationship8");
            DropColumn("dbo.Relationships", "Relationship9");
            DropColumn("dbo.Relationships", "Relationship10");
            DropColumn("dbo.Relationships", "Relationship11");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Relationships", "Relationship11", c => c.String());
            AddColumn("dbo.Relationships", "Relationship10", c => c.String());
            AddColumn("dbo.Relationships", "Relationship9", c => c.String());
            AddColumn("dbo.Relationships", "Relationship8", c => c.String());
            AddColumn("dbo.Relationships", "Relationship7", c => c.String());
            AddColumn("dbo.Relationships", "Relationship6", c => c.String());
            AddColumn("dbo.Relationships", "Relationship5", c => c.String());
            AddColumn("dbo.Relationships", "Relationship4", c => c.String());
            AddColumn("dbo.Relationships", "Relationship3", c => c.String());
            AddColumn("dbo.Relationships", "Relationship2", c => c.String());
            AddColumn("dbo.Relationships", "Relationship1", c => c.String());
            AddColumn("dbo.Relationships", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" }, "dbo.Relationships");
            DropForeignKey("dbo.Relationships", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.AspNetUsers", new[] { "Relationship_RelationshipId", "Relationship_UserProfileId" });
            DropIndex("dbo.Relationships", new[] { "UserProfileId" });
            DropPrimaryKey("dbo.Relationships");
            DropColumn("dbo.Relationships", "RelationshipValue");
            DropColumn("dbo.Relationships", "UserProfileId");
            DropColumn("dbo.Relationships", "RelationshipId");
            DropColumn("dbo.AspNetUsers", "Relationship_UserProfileId");
            DropColumn("dbo.AspNetUsers", "Relationship_RelationshipId");
            AddPrimaryKey("dbo.Relationships", "Id");
            CreateIndex("dbo.Relationships", "Id");
            AddForeignKey("dbo.Relationships", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
