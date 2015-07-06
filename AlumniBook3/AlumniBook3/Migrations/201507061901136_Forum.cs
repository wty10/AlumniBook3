namespace AlumniBook3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        DiscussionID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        ReplyID = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.DiscussionID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.User_ID)
                .Index(t => t.CategoryID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussions", "User_ID", "dbo.UserProfiles");
            DropForeignKey("dbo.Discussions", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Discussions", new[] { "User_ID" });
            DropIndex("dbo.Discussions", new[] { "CategoryID" });
            DropTable("dbo.Discussions");
            DropTable("dbo.Categories");
        }
    }
}
