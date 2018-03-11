using AutoMapper;
using DriveTracker.Entities;
using DriveTracker.Models;
using DriveTracker.Repositories;
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

        public CarsController(ICarRepository carRepository,IUserRepository userRepository,IAppRepository appRepository)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
            _appRepository = appRepository;
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

        [HttpGet, Route("{id}")]

        public IHttpActionResult GetCar(int userId,int id)
        {
            try
            {
                if (!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var carFromRepo = _carRepository.GetCarForUser(userId,id);

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

                var car = Mapper.Map<Car>(carFromBody);

                _carRepository.AddCarForUser(userId, car);

                if(!_appRepository.Commit())
                {
                    return InternalServerError();
                }

                var carToReturn = Mapper.Map<CarDto>(car);
                //do zmiany
                return CreatedAtRoute("GetCar",new {id = carToReturn.Id }, carToReturn);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}