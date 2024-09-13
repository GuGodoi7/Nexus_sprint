using _NEXUS.Models;

namespace _NEXUS.Repository.Interfaces
{
    public interface IPedidosRepository
    {
        Task<IEnumerable<PedidosModel>> GetAllAsync();
        Task<PedidosModel> GetByIdAsync(int id);
        Task AddAsync(PedidosModel pedido);
        Task UpdateAsync(PedidosModel pedido);
        Task DeleteAsync(int id);
    }
}
