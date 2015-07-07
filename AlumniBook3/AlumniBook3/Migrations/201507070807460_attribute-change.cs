namespace AlumniBook3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attributechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussions", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discussions", "Email");
        }
    }
}
