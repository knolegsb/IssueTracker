namespace IssueTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedIssueAndLogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        IssueID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Body = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        IssueType = c.Int(nullable: false),
                        AssignedTo_Id = c.String(maxLength: 128),
                        Creator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IssueID)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedTo_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .Index(t => t.AssignedTo_Id)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.LogActions",
                c => new
                    {
                        logActionID = c.Int(nullable: false, identity: true),
                        PerformedAt = c.DateTime(nullable: false),
                        Controller = c.String(),
                        Action = c.String(),
                        Description = c.String(),
                        PerformedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.logActionID)
                .ForeignKey("dbo.AspNetUsers", t => t.PerformedBy_Id)
                .Index(t => t.PerformedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogActions", "PerformedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "AssignedTo_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LogActions", new[] { "PerformedBy_Id" });
            DropIndex("dbo.Issues", new[] { "Creator_Id" });
            DropIndex("dbo.Issues", new[] { "AssignedTo_Id" });
            DropTable("dbo.LogActions");
            DropTable("dbo.Issues");
        }
    }
}
