using AutoMapper;
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
    [RoutePrefix("api/fuels")]
    public class FuelsController : ApiController
    {
        private IFuelRepository _fuelRepository;

        public FuelsController(IFuelRepository fuelRepository)
        {
            _fuelRepository = fuelRepository;
        }
        [HttpGet,Route("")]
        public IHttpActionResult GetFuels()
        {
            try
            {
                var fuelsFromRepo = _fuelRepository.GetFuels();

                var fuels = Mapper.Map<IEnumerable<FuelDto>>(fuelsFromRepo);

                return Ok(fuels);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            
        }
        [HttpGet, Route("{id}")]
        public IHttpActionResult GetFuel(int id)
        {
            try
            {
                var fuelFromRepo = _fuelRepository.GetFuel(id);
                
                if(fuelFromRepo==null)
                {
                    return NotFound();
                }

                var fuel = Mapper.Map<FuelDto>(fuelFromRepo);

                return Ok(fuel);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}