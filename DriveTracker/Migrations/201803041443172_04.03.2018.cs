namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04032018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToReceive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Payed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Received = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Month = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayerId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        JourneyId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateTime = c.DateTime(nullable: false),
                        IsPayed = c.Boolean(nullable: false),
                        PaymentAcceptanceRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journeys", t => t.JourneyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PayerId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.ReceiverId, cascadeDelete: false)
                .Index(t => t.PayerId)
                .Index(t => t.ReceiverId)
                .Index(t => t.JourneyId);
            
            CreateTable(
                "dbo.Journeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destination = c.String(nullable: false),
                        Start = c.String(nullable: false),
                        Length = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        FuelConsumption = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PaymentAcceptanceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserJourneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destination = c.String(nullable: false),
                        Start = c.String(nullable: false),
                        Length = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        JourneyId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journeys", t => t.JourneyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.JourneyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserJourneys", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserJourneys", "JourneyId", "dbo.Journeys");
            DropForeignKey("dbo.Payments", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.Payments", "PayerId", "dbo.Users");
            DropForeignKey("dbo.PaymentAcceptanceRequests", "Id", "dbo.Payments");
            DropForeignKey("dbo.Payments", "JourneyId", "dbo.Journeys");
            DropForeignKey("dbo.Journeys", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "UserId", "dbo.Users");
            DropIndex("dbo.UserJourneys", new[] { "JourneyId" });
            DropIndex("dbo.UserJourneys", new[] { "UserId" });
            DropIndex("dbo.PaymentAcceptanceRequests", new[] { "Id" });
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropIndex("dbo.Journeys", new[] { "CarId" });
            DropIndex("dbo.Payments", new[] { "JourneyId" });
            DropIndex("dbo.Payments", new[] { "ReceiverId" });
            DropIndex("dbo.Payments", new[] { "PayerId" });
            DropIndex("dbo.Balances", new[] { "UserId" });
            DropTable("dbo.UserJourneys");
            DropTable("dbo.PaymentAcceptanceRequests");
            DropTable("dbo.Cars");
            DropTable("dbo.Journeys");
            DropTable("dbo.Payments");
            DropTable("dbo.Users");
            DropTable("dbo.Balances");
        }
    }
}
