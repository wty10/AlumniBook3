namespace AlumniBook3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussions", "Discussion_DiscussionID", c => c.Int());
            CreateIndex("dbo.Discussions", "Discussion_DiscussionID");
            AddForeignKey("dbo.Discussions", "Discussion_DiscussionID", "dbo.Discussions", "DiscussionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussions", "Discussion_DiscussionID", "dbo.Discussions");
            DropIndex("dbo.Discussions", new[] { "Discussion_DiscussionID" });
            DropColumn("dbo.Discussions", "Discussion_DiscussionID");
        }
    }
}
