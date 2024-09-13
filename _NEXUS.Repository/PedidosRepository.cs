using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NX.Database;

namespace _NEXUS.Repository
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly NXContext _context;

        public PedidosRepository(NXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PedidosModel>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<PedidosModel> GetByIdAsync(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task AddAsync(PedidosModel pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PedidosModel pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
