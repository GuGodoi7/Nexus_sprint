using _NEXUS.Models;

namespace _NEXUS.Service.InterfacesService
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioModel>> GetAllUsersAsync();
        Task<UsuarioModel> GetUserByIdAsync(int id);
        Task<UsuarioModel> CreateUserAsync(UsuarioModel user);
        Task UpdateUserAsync(int id, UsuarioModel user);
        Task DeleteUserAsync(int id);
    }
}
