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
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosService(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public async Task<IEnumerable<ProdutosModel>> GetAllProdutosAsync()
        {
            return await _produtosRepository.GetAllAsync();
        }

        public async Task<ProdutosModel> GetProdutoByIdAsync(int id)
        {
            return await _produtosRepository.GetByIdAsync(id);
        }

        public async Task<ProdutosModel> CreateProdutoAsync(ProdutosModel produto)
        {
            await _produtosRepository.AddAsync(produto);
            return produto;
        }

        public async Task UpdateProdutoAsync(int id, ProdutosModel produto)
        {
            await _produtosRepository.UpdateAsync(produto);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            await _produtosRepository.DeleteAsync(id);
        }
    }
}
