using AutoMapper;
using DriveTracker.Entities;
using DriveTracker.Models.Journeys;
using DriveTracker.Repositories;
using DriveTracker.Services;
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
        private IJourneyService _journeyService;

        public JourneysController(IJourneyRepository journeyRepository,IUserRepository userRepository,ICarRepository carRepository,IJourneyService journeyService)
        {
            _journeyRepository = journeyRepository;
            _userRepository = userRepository;
            _carRepository = carRepository;
            _journeyService = journeyService;

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

        //[HttpPost,Route("cars/{carId}/journeys")]
        //send notification to users, create payments,calculate price,
        //public ihttpactionresult createjourney([frombody]journeyforcreationdto journeyfrombody, int userid, int carid)
        //{
        //    try
        //    {
        //        if (journeyfrombody == null)
        //        {
        //            return badrequest();
        //        }

        //        if (!_carrepository.carexistsforuser(userid, carid))
        //        {
        //            return notfound();
        //        }

        //        if (!modelstate.isvalid)
        //        {
        //            return badrequest(modelstate);
        //        }

        //        var journey = mapper.map<journey>(journeyfrombody);

        //        _journeyservice.givetotalprice(journey, (double)journeyfrombody.priceforliter);
        //        //paymentservice wygeneruje paymenty
        //        //user service wyedytuje pola zwiazane z platnosciami
        //        //notification service wysle notyfikacje albo repozytorium

        //        _journeyrepository.addjourneyforuserandcar(userid, carid, journey);

        //    }
        //    catch (exception)
        //    {
        //        return internalservererror();
        //    }

        //}
    }
}