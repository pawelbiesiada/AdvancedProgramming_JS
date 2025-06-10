using Microsoft.AspNetCore.Mvc;
using MyWebApiServer.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace MyWebApiServer.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserManagerController : Controller
    {
        public UserManagerController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, "", typeof(User))]
        [SwaggerResponse(404)]
        [ValidateAntiForgeryToken]
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            //StatusCode(200,)
            return user != null ? Ok(user) : NotFound($"User with Id {id} does not exist.");
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, "Zaktualizowano użytkownika", typeof(User))]
        [SwaggerResponse(404, "Nie znaleziono użytkownika")]
        public ActionResult<User> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound("Nie znaleziono użytkownika");

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.isActive = updatedUser.isActive;

            return Ok(user);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(204, "Użytkownik usunięty")]
        [SwaggerResponse(404, "Nie znaleziono użytkownika")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound("Nie znaleziono użytkownika");

            _users.Remove(user);
            return NoContent();
        }

        [HttpPost]
        [SwaggerResponse(201, "Utworzono użytkownika", typeof(User))]
        [SwaggerResponse(400, "Nieprawidłowe dane")]
        public ActionResult<User> CreateUser([FromBody] User newUser)
        {
            if (_users.Any(u => u.Id == newUser.Id))
                return BadRequest("Użytkownik o takim ID już istnieje");

            _users.Add(newUser);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }


        private static List<User> _users = new List<User>()
        {
            new User(){Id = 1, Name = "John", Email = "John@gmail.com", isActive = true },
            new User(){Id = 2, Name = "Bob", Email = "Bob@gmail.com", isActive = false },
            new User(){Id = 3, Name = "Steven", Email = "Steven@gmail.com", isActive = true },
        };

        private readonly ILogger logger;
    }
}
