using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
        }

        public Car GetCarForUser(int userId, int id,bool journeys)
        {
            if(journeys)
            {
                return _context.Cars.Include(c=>c.Journeys)
                                    .Where(c => c.UserId == userId)
                                    .FirstOrDefault(c => c.Id == id);
            }
            return _context.Cars.Where(c => c.UserId == userId)
                                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Car> GetCarsForUser(int userId, bool journeys)
        {          
            if(journeys)
            {
                //return _context.Cars.Include(c => c.Journeys).Where(c => c.UserId == userId);
              return _context.Cars.Include(c => c.Journeys)
                                  .Where(c => c.UserId == userId);
            }
            
           
            
            return _context.Cars.Where(c => c.UserId == userId);

        }

        public void UpdateCar()
        {
            //empty method
        }
    }
}