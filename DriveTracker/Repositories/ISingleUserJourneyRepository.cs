using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Repositories
{
    public interface ISingleUserJourneyRepository
    {
        void AddSingleUserJourneyForUserAndJourney(int userId,int journeyId,SingleUserJourney singleUserJourney);
        IQueryable<SingleUserJourney> GetSingleUserJourneysForUserAndJourney(int userId, int journeyId);
        SingleUserJourney GetSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id);
        void DeleteSingleUserJourneyForUserAndJourney(int userId, int journeyId, int id);

    }
}
