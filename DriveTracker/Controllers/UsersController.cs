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

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private IUserRepository _userRepository;     
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet,Route("")]
        public IHttpActionResult GetUsers(bool cars = false, bool balances = false, bool payments = false, bool userJourneys = false)
        {
            var users = _userRepository.GetUsers();

            Mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(users);
        }

        [HttpGet,Route("{id}")]
        public IHttpActionResult GetUser(int id, bool cars = false, bool balances = false, bool payments = false, bool userJourneys = false)
        {
            var user = _userRepository.GetUser(id);
            if(user==null)
            {
                return NotFound();
            }

            Mapper.Map<UserDto>(user);

            return Ok(user);
        }

        // POST api/<controller>
        /*public void Post([FromBody]string value)
        {
        }*/

        // PUT api/<controller>/5
        /*public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE api/<controller>/5
        /*public void Delete(int id)
        {
        }*/
    }
}