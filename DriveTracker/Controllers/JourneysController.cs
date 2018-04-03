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
        private IPaymentService _paymentService;
        private IAppRepository _appRepository;
        private IUserService _userService;
        private IPaymentRepository _paymentRepository;

        public JourneysController(IJourneyRepository journeyRepository,
                                  IUserRepository userRepository,
                                  ICarRepository carRepository,
                                  IJourneyService journeyService,
                                  IPaymentService paymentService,
                                  IAppRepository appRepository,
                                  IUserService userService,
                                  IPaymentRepository paymentRepository)
        {
            _journeyRepository = journeyRepository;
            _userRepository = userRepository;
            _carRepository = carRepository;
            _journeyService = journeyService;
            _paymentService = paymentService;
            _appRepository = appRepository;
            _userService = userService;
            _paymentRepository = paymentRepository;


        }

        [HttpGet]
        [Route("cars/{carId}/journeys")]
        [Route("journeys")]
        public IHttpActionResult GetJourneys(int userId, bool passengerRoute,int? carId=null)
        {
            try
            {
                
                if (carId == null)
                {
                    if (!_userRepository.UserExists(userId))
                    {
                        return NotFound();
                    }

                    var journeys = _journeyRepository.GetJourneysForUser(userId,passengerRoute);

                    Mapper.Map<IEnumerable<JourneyDto>>(journeys);

                    return Ok(journeys);
                }
                else
                {
                    if(!_carRepository.CarExistsForUser(userId,(int)carId))
                    {
                        return NotFound();
                    }

                    var journeys = _journeyRepository.GetJourneysForUserAndCar(userId, (int)carId, passengerRoute);

                    Mapper.Map<IEnumerable<JourneyDto>>(journeys);

                    return Ok(journeys);
                }

            }
            catch(Exception)
            {
                return InternalServerError();
            }
            
        }

        [HttpGet]
        [Route("cars/{carId}/journeys/{id}",Name ="GetJourneyForUserAndCar")]
        [Route("journeys/{id}")]
        public IHttpActionResult GetJourney(int userId, int id, bool passangerRoutes, int? carId = null)
        {
            try
            {

                if (carId == null)
                {
                    if (!_userRepository.UserExists(userId))
                    {
                        return NotFound();
                    }

                    var journey = _journeyRepository.GetJourneyForUser(userId,id, passangerRoutes);

                    if(journey==null)
                    {
                        return NotFound();
                    }

                    Mapper.Map<JourneyDto>(journey);

                    return Ok(journey);
                }
                else
                {
                    if (!_carRepository.CarExistsForUser(userId, (int)carId))
                    {
                        return NotFound();
                    }

                    var journey = _journeyRepository.GetJourneyForUserAndCar(userId, (int)carId, id, passangerRoutes);

                    Mapper.Map<JourneyDto>(journey);

                    if(journey==null)
                    {
                        return NotFound();
                    }

                    return Ok(journey);
                }

            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        [HttpPost, Route("cars/{carId}/journeys")]
        //send notification to users
        public IHttpActionResult CreateJourney([FromBody]JourneyForCreationDto JourneyFromBody, int userId, int carId)
        {
            try
            {
                if (JourneyFromBody == null)
                {
                    return BadRequest();
                }

                var car = _carRepository.GetCarForUser(userId, carId, false);

                //if (!_carRepository.CarExistsForUser(userId, carId))
                //{
                //    return NotFound();
                //}

                if(car==null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var journey = Mapper.Map<Journey>(JourneyFromBody);

                _journeyService.GiveTotalPrices(journey, (double)JourneyFromBody.PriceForLiter,car.FuelConsumption100km);

                var payments = _paymentService.GeneratePayments(journey);

                _userService.EditUserPaymentStatistics(payments);

                //notification service albo repozytorium wysle notyfikacje 

                _journeyRepository.AddJourneyForUserAndCar(userId, carId, journey);

                _paymentRepository.AddPayments(payments);

                if(!_appRepository.Commit())
                {
                    return InternalServerError();
                }

                var journeyToReturn = Mapper.Map<JourneyDto>(journey);

                return CreatedAtRoute("GetJourneyForUserAndCar", new { userId = userId, id = journey.Id, passengerRoutes = true, carId = carId }, journeyToReturn);

            }
            catch (Exception e)
            {
                return InternalServerError();
            }

        }
    }
}