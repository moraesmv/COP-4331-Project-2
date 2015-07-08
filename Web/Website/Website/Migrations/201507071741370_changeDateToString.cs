namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDateToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TopScoresAllTimeEntries", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.TopScoresTodayEntries", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.TopTimesAllTimeEntries", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.TopTimesTodayEntries", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TopTimesTodayEntries", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopTimesAllTimeEntries", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopScoresTodayEntries", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TopScoresAllTimeEntries", "Date", c => c.DateTime(nullable: false));
        }
    }
}
