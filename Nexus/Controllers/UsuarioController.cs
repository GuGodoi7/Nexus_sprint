using _NEXUS.Models;
using _NEXUS.Repository;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<UsuarioModel>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            LogManager.Instance.Log("Obtendo todos os usuários.");
            var users = await _usersService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUser(int id)
        {
            LogManager.Instance.Log($"Obtendo usuário com ID: {id}");
            var user = await _usersService.GetUserByIdAsync(id);

            if (user == null)
            {
                LogManager.Instance.Log("Usuário não encontrado.");
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(UsuarioModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioModel user)
        {
            if (!ModelState.IsValid)
            {
                LogManager.Instance.Log("Modelo de usuário inválido.");
                return BadRequest(ModelState);
            }

            LogManager.Instance.Log("Criando novo usuário.");
            var createdUser = await _usersService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.IdUsuario }, createdUser);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsuarioModel user)
        {
            if (!ModelState.IsValid)
            {
                LogManager.Instance.Log("Modelo de usuário inválido.");
                return BadRequest();
            }

            if (id != user.IdUsuario)
            {
                LogManager.Instance.Log("ID do usuário não corresponde.");
                return BadRequest();
            }

            try
            {
                LogManager.Instance.Log($"Atualizando usuário com ID: {id}");
                await _usersService.UpdateUserAsync(id, user);
            }
            catch (KeyNotFoundException)
            {
                LogManager.Instance.Log("Usuário não encontrado para atualização.");
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                LogManager.Instance.Log($"Deletando usuário com ID: {id}");
                await _usersService.DeleteUserAsync(id);
            }
            catch (KeyNotFoundException)
            {
                LogManager.Instance.Log("Usuário não encontrado para exclusão.");
                return NotFound();
            }

            return NoContent();
        }
    }
}
