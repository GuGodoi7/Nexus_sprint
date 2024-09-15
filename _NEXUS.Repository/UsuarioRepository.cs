using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NX.Database;


namespace _NEXUS.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly NXContext _context;

        public UsuarioRepository(NXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioModel>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddAsync(UsuarioModel Usuarios)
        {
            _context.Usuarios.Add(Usuarios);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioModel Usuarios)
        {
            _context.Usuarios.Update(Usuarios);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Usuarios = await _context.Usuarios.FindAsync(id);
            if (Usuarios != null)
            {
                _context.Usuarios.Remove(Usuarios);
                await _context.SaveChangesAsync();
            }
        }
    }
}
