using Microsoft.AspNetCore.Mvc;
using EventAPI.Models;
using EventAPI.Repositories;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser(User userDetails)
        {
            var createdUser = _userRepository.CreateUser(userDetails);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User userDetails)
        {
            var updatedUser = _userRepository.UpdateUser(id, userDetails);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deleted = _userRepository.DeleteUser(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
