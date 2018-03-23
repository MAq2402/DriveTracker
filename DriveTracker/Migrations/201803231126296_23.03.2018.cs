namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23032018 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Journeys", "Destination", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Journeys", "Start", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserJourneys", "Destination", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserJourneys", "Start", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserJourneys", "Start", c => c.String(nullable: false));
            AlterColumn("dbo.UserJourneys", "Destination", c => c.String(nullable: false));
            AlterColumn("dbo.Journeys", "Start", c => c.String(nullable: false));
            AlterColumn("dbo.Journeys", "Destination", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false));
        }
    }
}
