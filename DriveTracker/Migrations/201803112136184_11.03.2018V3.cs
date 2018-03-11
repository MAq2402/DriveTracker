namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11032018V3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        PriceForLiter = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "FuelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "FuelId");
            AddForeignKey("dbo.Cars", "FuelId", "dbo.Fuels", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "FuelId", "dbo.Fuels");
            DropIndex("dbo.Cars", new[] { "FuelId" });
            DropColumn("dbo.Cars", "FuelId");
            DropTable("dbo.Fuels");
        }
    }
}
