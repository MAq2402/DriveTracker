using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.DbContexts;
using DriveTracker.Entities;

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
            throw new NotImplementedException();
        }

        public void DeleteJourneyForUser(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteJourneyForUserAndCar(int userId, int carId, int id)
        {
            throw new NotImplementedException();
        }

        public Journey GetJourneyForUser(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public Journey GetJourneyForUserAndCar(int userId, int carId, int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Journey> GetJourneysForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Journey> GetJourneysForUserAndCar(int userId, int carId)
        {
            throw new NotImplementedException();
        }

        public bool JourneyExistsForUser(int userId, int id)
        {
            throw new NotImplementedException();
        }
    }
}