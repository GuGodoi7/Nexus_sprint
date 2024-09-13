using _NEXUS.Models;

namespace _NEXUS.Repository.Interfaces
{
    public interface IProdutosRepository
    {
        Task<IEnumerable<ProdutosModel>> GetAllAsync();
        Task<ProdutosModel> GetByIdAsync(int id);
        Task AddAsync(ProdutosModel produto);
        Task UpdateAsync(ProdutosModel produto);
        Task DeleteAsync(int id);
    }
}
