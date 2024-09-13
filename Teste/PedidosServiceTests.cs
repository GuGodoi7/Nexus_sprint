using _NEXUS.Models;
using _NEXUS.Service;
using _NEXUS.Repository.Interfaces;
using Moq;

namespace Teste
{
    public class PedidosServiceTests
    {
        private readonly Mock<IPedidosRepository> _mockPedidosRepository;
        private readonly PedidosService _pedidosService;

        public PedidosServiceTests()
        {

            _mockPedidosRepository = new Mock<IPedidosRepository>();


            _pedidosService = new PedidosService(_mockPedidosRepository.Object);
        }

        [Fact]
        public async Task GetAllPedidos_ShouldReturnListOfPedidos()
        {

            var pedidosList = new List<PedidosModel>
            {
                new PedidosModel { IdPedido = 1, CodigoPedido = 1001, Quantidade = 5, ValorPedido = 500 },
                new PedidosModel { IdPedido = 2, CodigoPedido = 1002, Quantidade = 10, ValorPedido = 1000 }
            };

            _mockPedidosRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(pedidosList);


            var result = await _pedidosService.GetAllPedidosAsync();

            var resultList = result.ToList();


            Assert.NotNull(resultList);
            Assert.Equal(2, resultList.Count);
            Assert.Equal(1001, resultList[0].CodigoPedido);
            Assert.Equal(1002, resultList[1].CodigoPedido);
        }

        [Fact]
        public async Task GetPedidoById_ShouldReturnPedido_WhenPedidoExists()
        {

            var pedido = new PedidosModel { IdPedido = 1, CodigoPedido = 1001, Quantidade = 5,  ValorPedido = 500 };

            _mockPedidosRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(pedido);

            var result = await _pedidosService.GetPedidoByIdAsync(1);


            Assert.NotNull(result);
            Assert.Equal(1001, result.CodigoPedido);
            Assert.Equal(5, result.Quantidade);
            Assert.Equal(500, result.ValorPedido);
        }

        [Fact]
        public async Task GetPedidoById_ShouldReturnNull_WhenPedidoDoesNotExist()
        {

            _mockPedidosRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((PedidosModel)null);

            var result = await _pedidosService.GetPedidoByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreatePedido_ShouldAddPedido()
        {

            var newPedido = new PedidosModel { CodigoPedido = 1003, Quantidade = 15, ValorPedido = 1500 };

            await _pedidosService.CreatePedidoAsync(newPedido);


            _mockPedidosRepository.Verify(repo => repo.AddAsync(newPedido), Times.Once);
        }
    }
}