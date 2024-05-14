using ClanSystem.Server.Entities;
using ClanSystem.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClanSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _userServices.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            await _userServices.CreateUser(user);
            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
        }

        [HttpPost]
        [Route("Check")]
        public async Task<ActionResult<User>> GetUserByUsername(User user)
        {
            var userFound = await _userServices.GetUserByUsername(user.Username);
            if (userFound == null)
            {
                return NotFound();
            }
            Console.WriteLine("Hello, World");
            return userFound;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userServices.UpdateUser(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userServices.DeleteUser(id);
            return NoContent();
        }
    }
}
