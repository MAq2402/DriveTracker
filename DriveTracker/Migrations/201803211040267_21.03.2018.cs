namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21032018 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "FuelId", "dbo.Fuels");
            DropForeignKey("dbo.PaymentAcceptanceRequests", "Id", "dbo.Payments");
            DropIndex("dbo.Cars", new[] { "FuelId" });
            DropIndex("dbo.PaymentAcceptanceRequests", new[] { "Id" });
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        NotifiedUserId = c.Int(nullable: false),
                        NotifyingUserId = c.Int(nullable: false),
                        Message = c.String(nullable: false),
                        NotificationType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.NotifiedUserId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.NotifyingUserId, cascadeDelete: false)
                .Index(t => t.NotifiedUserId)
                .Index(t => t.NotifyingUserId);
            
            AddColumn("dbo.Cars", "FuelType", c => c.Int(nullable: false));
            AddColumn("dbo.Journeys", "PricePerKm", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Cars", "FuelId");
            DropColumn("dbo.Payments", "PaymentAcceptanceRequestId");
            DropTable("dbo.Fuels");
            DropTable("dbo.PaymentAcceptanceRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaymentAcceptanceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        PriceForLiter = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Payments", "PaymentAcceptanceRequestId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "FuelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Notifications", "NotifyingUserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "NotifiedUserId", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "NotifyingUserId" });
            DropIndex("dbo.Notifications", new[] { "NotifiedUserId" });
            DropColumn("dbo.Journeys", "PricePerKm");
            DropColumn("dbo.Cars", "FuelType");
            DropTable("dbo.Notifications");
            CreateIndex("dbo.PaymentAcceptanceRequests", "Id");
            CreateIndex("dbo.Cars", "FuelId");
            AddForeignKey("dbo.PaymentAcceptanceRequests", "Id", "dbo.Payments", "Id");
            AddForeignKey("dbo.Cars", "FuelId", "dbo.Fuels", "Id", cascadeDelete: true);
        }
    }
}
