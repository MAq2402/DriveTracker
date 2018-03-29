using DriveTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DriveTracker.Controllers
{
    [RoutePrefix("api/users/{userId}/journeys/{journeyId}/singleUserJourneys")]
    public class PassengerRoutesController : ApiController
    {
        private IPassengerRouteRepository _singleUserJourneyRepository;

        public PassengerRoutesController(IPassengerRouteRepository singleUserJourneyRepository)
        {
            _singleUserJourneyRepository = singleUserJourneyRepository;
        }
        [HttpGet(),Route("")]
        public IHttpActionResult GetSingleUserJourneys(int userId,int journeyId)
        {
            return Ok();
        }

        [HttpGet(), Route("")]
        public IHttpActionResult GetSingleUserJourney(int userId, int journeyId,int Id)
        {
            return Ok();
        }

    }
}