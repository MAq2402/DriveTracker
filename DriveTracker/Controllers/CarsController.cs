using AutoMapper;
using DriveTracker.Entities;
using DriveTracker.Models.Cars;
using DriveTracker.Models.Users;
using DriveTracker.Repositories;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

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
        public IHttpActionResult GetCars(int userId,bool journeys = false)
        {

            try
            {
                if(!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var carsFromRepo = _carRepository.GetCarsForUser(userId,journeys);

                var cars = Mapper.Map<IEnumerable<CarDto>>(carsFromRepo);

                return Ok(cars);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            
        }

        [HttpGet, Route("{id}",Name ="GetCar")]

        public IHttpActionResult GetCar(int userId,int id, bool journeys=false)
        {
            try
            {
                if (!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var carFromRepo = _carRepository.GetCarForUser(userId,id,journeys);

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

                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if(!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var car = Mapper.Map<Car>(carFromBody);


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

                var car = _carRepository.GetCarForUser(userId, id,false);

                if(car ==null)
                {
                    return NotFound();
                }

                var carForPatch = Mapper.Map<CarForUpdateDto>(car);

                patchDoc.ApplyTo(carForPatch);

                Validate(carForPatch); // validation after patching

                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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

        [HttpDelete,Route("{id}")]
        public IHttpActionResult DeleteCar(int userId,int id)
        {
            try
            {
                if (!_userRepository.UserExists(userId))
                {
                    return NotFound();
                }

                var car = _carRepository.GetCarForUser(userId, id,false);

                if (car == null)
                {
                    return NotFound();
                }

                _carRepository.DeleteCar(car);

                if(!_appRepository.Commit())
                {
                    return InternalServerError();
                }

                return StatusCode(HttpStatusCode.NoContent);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
            

        }

    }
}