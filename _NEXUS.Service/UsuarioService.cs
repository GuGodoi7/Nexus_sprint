using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using _NEXUS.Service.InterfacesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _NEXUS.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usersRepository;

        public UsuarioService(IUsuarioRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<UsuarioModel>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task<UsuarioModel> GetUserByIdAsync(int id)
        {
            return await _usersRepository.GetByIdAsync(id);
        }

        public async Task<UsuarioModel> CreateUserAsync(UsuarioModel user)
        {
            await _usersRepository.AddAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(int id, UsuarioModel user)
        {
            var existingUser = await _usersRepository.GetByIdAsync(id);
            if (existingUser != null)
            {
                existingUser.NomeUsuario = user.NomeUsuario;
                existingUser.CPF = user.CPF;
                await _usersRepository.UpdateAsync(existingUser);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            await _usersRepository.DeleteAsync(id);
        }
    }
}
