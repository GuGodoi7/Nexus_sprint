using _NEXUS.Models;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;

namespace Nexus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidosModel>>> GetPedidos()
        {
            var pedidos = await _pedidosService.GetAllPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosModel>> GetPedido(int id)
        {
            var pedido = await _pedidosService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<PedidosModel>> PostPedido([FromForm] PedidosModel pedido)
        {
            var createdPedido = await _pedidosService.CreatePedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.IdPedido }, createdPedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, [FromForm] PedidosModel pedido)
        {
            if (id != pedido.IdPedido)
            {
                return BadRequest();
            }
            try
            {
                await _pedidosService.UpdatePedidoAsync(id, pedido);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                await _pedidosService.DeletePedidoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
