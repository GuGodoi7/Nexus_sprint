using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using _NEXUS.Service.InterfacesService;

namespace _NEXUS.Service
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosService(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public async Task<IEnumerable<PedidosModel>> GetAllPedidosAsync()
        {
            return await _pedidosRepository.GetAllAsync();
        }

        public async Task<PedidosModel> GetPedidoByIdAsync(int id)
        {
            return await _pedidosRepository.GetByIdAsync(id);
        }

        public async Task<PedidosModel> CreatePedidoAsync(PedidosModel pedido)
        {
            await _pedidosRepository.AddAsync(pedido);
            return pedido;
        }

        public async Task UpdatePedidoAsync(int id, PedidosModel pedido)
        {
            await _pedidosRepository.UpdateAsync(pedido);
        }

        public async Task DeletePedidoAsync(int id)
        {
            await _pedidosRepository.DeleteAsync(id);
        }
    }
}