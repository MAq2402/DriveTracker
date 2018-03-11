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
        public IHttpActionResult GetUsers()
        {
            try
            {
                var usersFromRepo = _userRepository.GetUsers();

                var users = Mapper.Map<IEnumerable<UserDto>>(usersFromRepo);

                return Ok(users);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            
        }

        [HttpGet,Route("{id}")]
        public IHttpActionResult GetUser(int id)
        {
            try
            {
                var userFromRepo = _userRepository.GetUser(id);

                if (userFromRepo == null)
                {
                    return NotFound();
                }

                var user = Mapper.Map<UserDto>(userFromRepo);

                return Ok(user);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
           
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