using AutoMapper;
using DriveTracker.Entities;
using DriveTracker.Models;
using DriveTracker.Repositories;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DriveTracker.Controllers
{
    [RoutePrefix("api/users/{userId}/cars")]
    public class CarsController : ApiController
    {
        private ICarRepository _carRepository;
        private IUserRepository _userRepository;
        private IAppRepository _appRepository;
        private IFuelRepository _fuelRepository;

        public CarsController(ICarRepository carRepository,IUserRepository userRepository,IAppRepository appRepository,IFuelRepository fuelRepository)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
            _appRepository = appRepository;
            _fuelRepository = fuelRepository;
        }
        [HttpGet,Route("")]
        public IHttpActionResult GetCars(int userId)
        {

            try
            {
                if(!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var carsFromRepo = _carRepository.GetCarsForUser(userId);

                var cars = Mapper.Map<IEnumerable<CarDto>>(carsFromRepo);

                return Ok(cars);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            
        }

        [HttpGet, Route("{id}",Name ="GetCar")]

        public IHttpActionResult GetCar(int userId,int id)
        {
            try
            {
                if (!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var carFromRepo = _carRepository.GetCarForUser(userId,id);

                if(carFromRepo==null)
                {
                    return NotFound();
                }

                var car = Mapper.Map<CarDto>(carFromRepo);

                return Ok(car);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        
        [HttpPost,Route("")]
        public IHttpActionResult CreateCar([FromBody]CarForCreationDto carFromBody, int userId )
        {
            try
            {
                if(carFromBody==null)
                {
                    return BadRequest();
                }

                if(!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var fuel = _fuelRepository.GetFuel(carFromBody.FuelId);

                if(fuel==null)
                {
                    return NotFound();
                }

                var car = Mapper.Map<Car>(carFromBody);

               car.Fuel = fuel;

                _carRepository.AddCarForUser(userId,car);


                if(!_appRepository.Commit())
                {
                    return InternalServerError();
                }

                var carToReturn = Mapper.Map<CarDto>(car);

                return CreatedAtRoute("GetCar",new {id = carToReturn.Id }, carToReturn);
            }
            catch(Exception)
            {           
                return InternalServerError();
            }
        }

        [HttpPatch,Route("{id}")]

        public IHttpActionResult PatchCar([FromBody]JsonPatchDocument<CarForUpdateDto> patchDoc,int userId,int id)
        {
            try
            {
                if (patchDoc == null)
                {
                    return BadRequest();
                }

                if (!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var car = _carRepository.GetCarForUser(userId, id);

                if(car ==null)
                {
                    return NotFound();
                }

                var carForPatch = Mapper.Map<CarForUpdateDto>(car);

                patchDoc.ApplyTo(carForPatch);

                Mapper.Map(carForPatch,car);

                _carRepository.UpdateCar();

                if (!_appRepository.Commit())
                {
                    return InternalServerError();
                }

                var carToReturn = Mapper.Map<CarDto>(car);

                return Ok(carToReturn);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}