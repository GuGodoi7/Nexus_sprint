using _NEXUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _NEXUS.Service.InterfacesService
{
    public interface IPedidosService
    {
        Task<IEnumerable<PedidosModel>> GetAllPedidosAsync();
        Task<PedidosModel> GetPedidoByIdAsync(int id);
        Task<PedidosModel> CreatePedidoAsync(PedidosModel pedido);
        Task UpdatePedidoAsync(int id, PedidosModel pedido);
        Task DeletePedidoAsync(int id);
    }
}
