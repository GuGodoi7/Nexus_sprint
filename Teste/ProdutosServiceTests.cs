using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using _NEXUS.Service;
using Moq;

namespace Teste
{
    public class ProdutosServiceTests
    {
        private readonly Mock<IProdutosRepository> _mockProdutosRepository;
        private readonly ProdutosService _produtosService;

        public ProdutosServiceTests()
        {

            _mockProdutosRepository = new Mock<IProdutosRepository>();

            _produtosService = new ProdutosService(_mockProdutosRepository.Object);
        }

        [Fact]
        public async Task GetAllProdutos_ShouldReturnListOfProdutos()
        {
            var produtosList = new List<ProdutosModel>
            {
                new ProdutosModel { IdProduto = 1, NomeProduto = "Produto 1", TipoProduto = "Tipo 1", Marca = "Marca 1", Modelo = "Modelo 1", Quantidade = 10, ValorProduto = 100, DescricaoProduto = "Descricao do Produto 1" },
                new ProdutosModel { IdProduto = 2, NomeProduto = "Produto 2", TipoProduto = "Tipo 2", Marca = "Marca 2", Modelo = "Modelo 2", Quantidade = 20, ValorProduto = 200, DescricaoProduto = "Descricao do Produto 2" }
            };


            _mockProdutosRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(produtosList);

            var result = await _produtosService.GetAllProdutosAsync();


            var resultList = result.ToList();


            Assert.NotNull(resultList);
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Produto 1", resultList[0].NomeProduto);
            Assert.Equal("Produto 2", resultList[1].NomeProduto);
        }

        [Fact]
        public async Task GetProdutoById_ShouldReturnProduto_WhenProdutoExists()
        {

            var produto = new ProdutosModel { IdProduto = 1, NomeProduto = "Produto 1", TipoProduto = "Tipo 1", Marca = "Marca 1", Modelo = "Modelo 1", Quantidade = 10, ValorProduto = 100, DescricaoProduto = "Descricao do Produto 1" };

            _mockProdutosRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(produto);

            var result = await _produtosService.GetProdutoByIdAsync(1);


            Assert.NotNull(result);
            Assert.Equal("Produto 1", result.NomeProduto);
            Assert.Equal("Marca 1", result.Marca);
        }

        [Fact]
        public async Task GetProdutoById_ShouldReturnNull_WhenProdutoDoesNotExist()
        {

            _mockProdutosRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((ProdutosModel)null);


            var result = await _produtosService.GetProdutoByIdAsync(999);


            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProduto_ShouldAddProduto()
        {

            var newProduto = new ProdutosModel { NomeProduto = "Produto 3", TipoProduto = "Tipo 3", Marca = "Marca 3", Modelo = "Modelo 3", Quantidade = 15, ValorProduto = 150, DescricaoProduto = "Descricao do Produto 3" };


            await _produtosService.CreateProdutoAsync(newProduto);


            _mockProdutosRepository.Verify(repo => repo.AddAsync(newProduto), Times.Once);
        }
    }
}