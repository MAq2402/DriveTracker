using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.Entities;

namespace DriveTracker.Repositories
{
    public class PassengerRouteRepository : IPassengerRouteRepository
    {
        public void AddSingleUserJourneyForUserAndJourney(int userId, int journeyId, PassengerRoute singleUserJourney)
        {
            throw new NotImplementedException();
        }

        public void DeleteSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id)
        {
            throw new NotImplementedException();
        }

        public PassengerRoute GetSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PassengerRoute> GetSingleUserJourneysForUserAndJourney(int userId, int journeyId)
        {
            throw new NotImplementedException();
        }
    }
}