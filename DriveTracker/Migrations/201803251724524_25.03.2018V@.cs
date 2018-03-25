namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25032018V : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SingleUserJourneys", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SingleUserJourneys", "TotalPrice");
        }
    }
}
