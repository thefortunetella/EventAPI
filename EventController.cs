using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EventAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace EventAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<User> users = new List<User>();

        [HttpPost("users")]
        [AllowAnonymous] // Não requer autenticação para criar usuário
        public ActionResult<User> CreateUser(User newUser)
        {
            users.Add(newUser);
            return CreatedAtAction(nameof(GetUser), new { username = newUser.Username }, newUser);
        }

        [HttpGet("users/{username}")]
        public ActionResult<User> GetUser(string username)
        {
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser == null)
            {
                return Unauthorized();
            }

            var key = Encoding.ASCII.GetBytes("chave_super_secreta_aqui");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, existingUser.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetEvent(string id)
        {
            // Lógica para obter um evento por ID
            Event foundEvent = null; 
            if (foundEvent == null)
            {
                return NotFound();
            }
            return foundEvent;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(string id, Event updatedEvent)
        {
            // Lógica para atualizar um evento por ID
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(string id)
        {
            // Lógica para deletar um evento por ID
            return NoContent();
        }
    }
}
