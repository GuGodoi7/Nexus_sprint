using _NEXUS.Models;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;

namespace Nexus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuarioService _usersService;

        public UsersController(IUsuarioService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _usersService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] UsuarioModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _usersService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.IdUsuario }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromForm] UsuarioModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _usersService.UpdateUserAsync(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _usersService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}

