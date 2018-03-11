namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11032018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Balances", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Balances", "Year");
        }
    }
}
