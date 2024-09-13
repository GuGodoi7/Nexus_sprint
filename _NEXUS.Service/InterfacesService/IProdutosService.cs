using _NEXUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _NEXUS.Service.InterfacesService
{
    public interface IProdutosService
    {
        Task<IEnumerable<ProdutosModel>> GetAllProdutosAsync();
        Task<ProdutosModel> GetProdutoByIdAsync(int id);
        Task<ProdutosModel> CreateProdutoAsync(ProdutosModel produto);
        Task UpdateProdutoAsync(int id, ProdutosModel produto);
        Task DeleteProdutoAsync(int id);
    }
}
