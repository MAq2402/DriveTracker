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
        public Car GetCar(int userId, int id)
        {
            return _context.Cars.Where(c => c.UserId == userId).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Car> GetCars(int userId)
        {
            return _context.Cars.Where(c => c.UserId == userId);
        }
    }
}