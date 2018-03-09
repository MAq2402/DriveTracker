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
        [HttpGet,Route("")]
        public IEnumerable<string> GetCars()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet, Route("{id}")]
        public string GetCar(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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