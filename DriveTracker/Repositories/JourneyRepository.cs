using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.DbContexts;
using DriveTracker.Entities;
using System.Data.Entity;

namespace DriveTracker.Repositories
{
    public class JourneyRepository : IJourneyRepository
    {
        private AppDbContext _context;

        public JourneyRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddJourneyForUserAndCar(int userId, int carId,Journey journey)
        {
            journey.CarId = carId;
            _context.Users.FirstOrDefault(u => u.Id == userId)
                    .Journeys.Add(journey);
        }

        public void DeleteJourneyForUser(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteJourneyForUserAndCar(int userId, int carId, int id)
        {
            throw new NotImplementedException();
        }

        public Journey GetJourneyForUser(int userId, int id, bool singleUserJourney)
        {
            throw new NotImplementedException();
        }

        public Journey GetJourneyForUserAndCar(int userId, int carId, int id, bool singleUserJourney)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Journey> GetJourneysForUser(int userId, bool singleUserJourney)
        {
            if (singleUserJourney)
            {
                return _context.Journeys.Where(j => j.UserId == userId)
                                        .Include(j => j.PassengerRoutes);
            }
            return _context.Journeys.Where(j => j.UserId == userId);
        }

        public IQueryable<Journey> GetJourneysForUserAndCar(int userId, int carId, bool singleUserJourney)
        {
            if(singleUserJourney)
            {
                return _context.Journeys.Where(j => j.UserId == userId && j.CarId == carId)
                                        .Include(j => j.PassengerRoutes);
            }
            return _context.Journeys.Where(j => j.UserId == userId && j.CarId == carId);
        }

        public bool JourneyExistsForUser(int userId, int id)
        {
            return _context.Journeys.Any(j => j.Id == id && j.UserId == userId);
        }
    }
}