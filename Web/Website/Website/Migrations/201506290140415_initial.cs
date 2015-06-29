namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaderboardEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 3),
                        LevelCompleteTime = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopScoresAllTimeEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 3),
                        LevelCompleteTime = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopScoresTodayEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 3),
                        LevelCompleteTime = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopTimesAllTimeEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 3),
                        LevelCompleteTime = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopTimesTodayEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 3),
                        LevelCompleteTime = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TopTimesTodayEntries");
            DropTable("dbo.TopTimesAllTimeEntries");
            DropTable("dbo.TopScoresTodayEntries");
            DropTable("dbo.TopScoresAllTimeEntries");
            DropTable("dbo.LeaderboardEntries");
        }
    }
}
