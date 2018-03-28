namespace DriveTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28032018v10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "BalanceId", "dbo.Balances");
            DropIndex("dbo.Users", new[] { "BalanceId" });
            AddColumn("dbo.Users", "ToPay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "ToReceive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "Payed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "Received", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Users", "BalanceId");
            DropTable("dbo.Balances");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Users", "BalanceId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Received");
            DropColumn("dbo.Users", "Payed");
            DropColumn("dbo.Users", "ToReceive");
            DropColumn("dbo.Users", "ToPay");
            CreateIndex("dbo.Users", "BalanceId");
            AddForeignKey("dbo.Users", "BalanceId", "dbo.Balances", "Id", cascadeDelete: true);
        }
    }
}
