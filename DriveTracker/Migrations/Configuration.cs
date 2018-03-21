namespace DriveTracker.Migrations
{
    using DriveTracker.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DriveTracker.DbContexts.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(DriveTracker.DbContexts.AppDbContext context)
        {

            var user1 = new User
            {
                FirstName = "Micha³",
                LastName = "Miciak",
                UserName = "MAq"
            };
            var user2 = new User
            {
                FirstName = "Kuba",
                LastName = "Jaworek",
                UserName = "Jawor"
            };
            var user3 = new User
            {
                FirstName = "Leo",
                LastName = "Messi",
                UserName = "Messi10"
            };

            context.Users.AddOrUpdate(u => u.UserName, user1);
            context.Users.AddOrUpdate(u => u.UserName, user2);
            context.Users.AddOrUpdate(u => u.UserName, user3);
            
            var car = new Car
            {
                FuelType =FuelType.lpg,
                UserId = 6,
                FuelConsumption100km = 1.7,
                Name = "xD",
            };
            context.Cars.AddOrUpdate(c => c.Name, car);
                
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
