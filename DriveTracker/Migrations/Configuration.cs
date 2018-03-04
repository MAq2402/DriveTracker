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
            context.Users.AddOrUpdate(u => u.UserName,
                new User
                {
                    FirstName = "Micha³",
                    LastName = "Miciak",
                    UserName = "MAq"
                });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
