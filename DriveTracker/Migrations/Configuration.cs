namespace DriveTracker.Migrations
{
    using DriveTracker.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DriveTracker.DbContexts.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(DriveTracker.DbContexts.AppDbContext context)
        {
            try
            {
                /*var user1 = new User
                {
                    FirstName = "Micha³",
                    LastName = "Miciak",
                    UserName = "MAq",

                };
                /*var user2 = new User
                {
                    FirstName = "Kuba",
                    LastName = "Jaworek",
                    UserName = "Jawor",
                };
                var user3 = new User
                {
                    FirstName = "Leo",
                    LastName = "Messi",
                    UserName = "Messi10",

                };
                 var balance2 = new Balance
                {
                    User = user2,
                    UserId = user2.Id
                };
                var balance3 = new Balance
                {
                    User = user3,
                    UserId = user3.Id
                };
                 

                var balance1 = new Balance
                {
                    User = user1,
                    UserId = user1.Id
                };
                */

                // context.Users.AddOrUpdate(u => u.UserName, );

                context.Users.AddOrUpdate(u => u.UserName,
                    new User
                    {
                        FirstName = "Micha³",
                        LastName = "Miciak",
                        UserName = "MAq",
                        Balance = new Balance()
                    });
                    
                //context.Users.AddOrUpdate(u => u.UserName, user2);
                //context.Users.AddOrUpdate(u => u.UserName, user3);

                

               //context.Balanaces.AddOrUpdate(b => b.UserId, balance1);
               //context.Balanaces.AddOrUpdate(b => b.UserId, balance2);
               //context.Balanaces.AddOrUpdate(b => b.UserId, balance3);

                var car = new Car
                {
                    FuelType = FuelType.lpg,
                    UserId = 6,
                    FuelConsumption100km = 1.7,
                    Name = "xD",
                };
                context.Cars.AddOrUpdate(c => c.Name, car);
            }
            catch(DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //Write to file
                System.IO.File.AppendAllLines(@"C:\Users\errors.txt", outputLines);
                throw;

                // Showing it on screen
                throw new Exception(string.Join(", ", outputLines.ToArray()));
            }


            
                
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
