using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIService.Database;
using APIService.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext databaseContext;

        public UserController()
        {
            databaseContext = new DatabaseContext();
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return databaseContext.Users.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return databaseContext.Users.Find(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                databaseContext.Users.Add(user);
                databaseContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, user);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
        }

    }
}
