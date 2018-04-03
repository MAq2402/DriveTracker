namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03042018 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SingleUserJourneys", newName: "PassengerRoutes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PassengerRoutes", newName: "SingleUserJourneys");
        }
    }
}
