using _NEXUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _NEXUS.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioModel>> GetAllAsync();
        Task<UsuarioModel> GetByIdAsync(int id);
        Task AddAsync(UsuarioModel usuario);
        Task UpdateAsync(UsuarioModel usuario);
        Task DeleteAsync(int id);
    }
}
