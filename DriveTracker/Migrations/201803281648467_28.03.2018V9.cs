namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28032018V9 : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        FuelConsumption100km = c.Double(nullable: false),
                        FuelType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Journeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destination = c.String(nullable: false, maxLength: 50),
                        Start = c.String(nullable: false, maxLength: 50),
                        Length = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.CarId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SingleUserJourneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destination = c.String(nullable: false, maxLength: 50),
                        Start = c.String(nullable: false, maxLength: 50),
                        Length = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        JourneyId = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journeys", t => t.JourneyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.JourneyId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        BalanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Balances", t => t.BalanceId, cascadeDelete: true)
                .Index(t => t.BalanceId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journeys", t => t.JourneyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PayerId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.ReceiverId, cascadeDelete: false)
                .Index(t => t.PayerId)
                .Index(t => t.ReceiverId)
                .Index(t => t.JourneyId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "UserId", "dbo.Users");
            DropForeignKey("dbo.Journeys", "UserId", "dbo.Users");
            DropForeignKey("dbo.SingleUserJourneys", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "NotifyingUserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "NotifiedUserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "PayerId", "dbo.Users");
            DropForeignKey("dbo.Payments", "JourneyId", "dbo.Journeys");
            DropForeignKey("dbo.Users", "BalanceId", "dbo.Balances");
            DropForeignKey("dbo.SingleUserJourneys", "JourneyId", "dbo.Journeys");
            DropForeignKey("dbo.Journeys", "CarId", "dbo.Cars");
            DropIndex("dbo.Notifications", new[] { "NotifyingUserId" });
            DropIndex("dbo.Notifications", new[] { "NotifiedUserId" });
            DropIndex("dbo.Payments", new[] { "JourneyId" });
            DropIndex("dbo.Payments", new[] { "ReceiverId" });
            DropIndex("dbo.Payments", new[] { "PayerId" });
            DropIndex("dbo.Users", new[] { "BalanceId" });
            DropIndex("dbo.SingleUserJourneys", new[] { "JourneyId" });
            DropIndex("dbo.SingleUserJourneys", new[] { "UserId" });
            DropIndex("dbo.Journeys", new[] { "UserId" });
            DropIndex("dbo.Journeys", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Payments");
            DropTable("dbo.Users");
            DropTable("dbo.SingleUserJourneys");
            DropTable("dbo.Journeys");
            DropTable("dbo.Cars");
            DropTable("dbo.Balances");
        }
    }
}
