using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.Entities;

namespace DriveTracker.Repositories
{
    public class SingleUserJourneyRepository : ISingleUserJourneyRepository
    {
        public void AddSingleUserJourneyForUserAndJourney(int userId, int journeyId, SingleUserJourney singleUserJourney)
        {
            throw new NotImplementedException();
        }

        public void DeleteSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id)
        {
            throw new NotImplementedException();
        }

        public SingleUserJourney GetSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SingleUserJourney> GetSingleUserJourneysForUserAndJourney(int userId, int journeyId)
        {
            throw new NotImplementedException();
        }
    }
}