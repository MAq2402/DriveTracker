using AutoMapper;
using DriveTracker.Entities;
using DriveTracker.Models.Journeys;
using DriveTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DriveTracker.Controllers
{
    [RoutePrefix("api/users/{userId}")]

    public class JourneysController : ApiController
    {
        private IJourneyRepository _journeyRepository;
        private IUserRepository _userRepository;
        private ICarRepository _carRepository;

        public JourneysController(IJourneyRepository journeyRepository,IUserRepository userRepository,ICarRepository carRepository)
        {
            _journeyRepository = journeyRepository;
            _userRepository = userRepository;
            _carRepository = carRepository;

        }

        [HttpGet]
        [Route("cars/{carId}/journeys")]
        [Route("journeys")]
        public IHttpActionResult GetJourneys(int userId, bool singleUserJourney,int? carId=null)
        {
            try
            {
                
                if (carId == null)
                {
                    if (!_userRepository.UserExists(userId))
                    {
                        return NotFound();
                    }

                    var journeys = _journeyRepository.GetJourneysForUser(userId,singleUserJourney);

                    Mapper.Map<IEnumerable<JourneyDto>>(journeys);

                    return Ok(journeys);
                }
                else
                {
                    if(!_carRepository.CarExistsForUser(userId,(int)carId))
                    {
                        return NotFound();
                    }

                    var journeys = _journeyRepository.GetJourneysForUserAndCar(userId, (int)carId, singleUserJourney);

                    Mapper.Map<IEnumerable<JourneyDto>>(journeys);

                    return Ok(journeys);
                }

            }
            catch(Exception)
            {
                return InternalServerError();
            }
            
        }

        /*[HttpPost,Route("cars/{carId}/journeys")]
        //send Notification to users, change balance for users, create payments,Calculate Price,
        public IHttpActionResult CreateJourney([FromBody]JourneyForCreationDto journeyFromBody,int userId,int carId)
        {
            try
            {
                if (journeyFromBody == null)
                {
                    return BadRequest();
                }

                if (!_carRepository.CarExistsForUser(userId, carId))
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var journey = Mapper.Map<Journey>(journeyFromBody);

                _journeyRepository.AddJourneyForUserAndCar(userId, carId, journey);

            }
            catch(Exception)
            {
                return InternalServerError();
            }
            
        }*/
    }
}