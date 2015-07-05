namespace AlumniBook3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        AchievementID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserProfile_ID = c.Int(),
                    })
                .PrimaryKey(t => t.AchievementID)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ID)
                .Index(t => t.UserProfile_ID);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        GraduatedYear = c.Int(nullable: false),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        PhotoUrl = c.String(),
                        Phone = c.Int(nullable: false),
                        Position = c.String(),
                        Company = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Achievements", "UserProfile_ID", "dbo.UserProfiles");
            DropIndex("dbo.Achievements", new[] { "UserProfile_ID" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Achievements");
        }
    }
}
