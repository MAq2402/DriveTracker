using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.DbContexts;
using DriveTracker.Entities;

namespace DriveTracker.Repositories
{
    public class CarRepository : ICarRepository
    {
        private AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }


        public void AddCarForUser(int userId,Car car)
        {
            _context.Users.FirstOrDefault(u => u.Id == userId).Cars.Add(car);
        }

        public Car GetCarForUser(int userId, int id)
        {
            return _context.Cars.Include("Fuel").Where(c => c.UserId == userId).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Car> GetCarsForUser(int userId)
        {
            return _context.Cars.Include("Fuel").Where(c => c.UserId == userId);

        }

        public void UpdateCar()
        {
            //empty method
        }
    }
}