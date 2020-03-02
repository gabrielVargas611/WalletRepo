using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletAPI.Contract;
using WalletAPI.Models;

namespace WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/User/All
        [HttpGet]
        [Route("All")]
        public ActionResult<List<User>> Get() => _userService.Get();

        // GET: api/User/5
        [HttpGet("{id}")]
        // [Route("User/GetOne")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.id.ToString() }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, User userp)
        {
            var user = _userService.Get(id);
            if (user == null)
                return NotFound();

            _userService.Update(id, userp);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
                return NotFound();

            _userService.Remove(user.id);

            return NoContent();
        }
    }
}
