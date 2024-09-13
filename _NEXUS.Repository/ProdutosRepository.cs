using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NX.Database;

namespace _NEXUS.Repository
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly NXContext _context;

        public ProdutosRepository(NXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutosModel>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ProdutosModel> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AddAsync(ProdutosModel produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProdutosModel produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
