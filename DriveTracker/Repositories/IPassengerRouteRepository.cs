using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Repositories
{
    public interface IPassengerRouteRepository
    {
        void AddSingleUserJourneyForUserAndJourney(int userId,int journeyId,PassengerRoute singleUserJourney);
        IQueryable<PassengerRoute> GetSingleUserJourneysForUserAndJourney(int userId, int journeyId);
        PassengerRoute GetSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id);
        void DeleteSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id);

    }
}
