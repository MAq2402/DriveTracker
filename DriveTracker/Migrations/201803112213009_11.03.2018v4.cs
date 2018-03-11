namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11032018v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "FuelConsumption100km", c => c.Double(nullable: false));
            DropColumn("dbo.Cars", "FuelConsumption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "FuelConsumption", c => c.Double(nullable: false));
            DropColumn("dbo.Cars", "FuelConsumption100km");
        }
    }
}
