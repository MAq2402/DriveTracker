namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25032018 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserJourneys", newName: "SingleUserJourneys");
            AddColumn("dbo.Journeys", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Journeys", "PricePerKm");
            DropColumn("dbo.SingleUserJourneys", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SingleUserJourneys", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Journeys", "PricePerKm", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Journeys", "TotalPrice");
            RenameTable(name: "dbo.SingleUserJourneys", newName: "UserJourneys");
        }
    }
}
