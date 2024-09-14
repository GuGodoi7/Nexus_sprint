using _NEXUS.Models;
using _NEXUS.Repository;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(typeof(IEnumerable<PedidosModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<PedidosModel>>> GetPedidos()
        {
            LogManager.Instance.Log("Obtendo todos os pedidos.");
            var pedidos = await _pedidosService.GetAllPedidosAsync();
            return Ok(pedidos);
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidosModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<PedidosModel>> GetPedido(int id)
        {
            LogManager.Instance.Log($"Obtendo pedido com ID: {id}");
            var pedido = await _pedidosService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                LogManager.Instance.Log("Pedido não encontrado.");
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PedidosModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<PedidosModel>> PostPedido([FromForm] PedidosModel pedido)
        {
            LogManager.Instance.Log("Criando novo pedido.");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPedido = await _pedidosService.CreatePedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.IdPedido }, createdPedido);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PutPedido(int id, [FromForm] PedidosModel pedido)
        {
            if (id != pedido.IdPedido)
            {
                LogManager.Instance.Log("ID do pedido não corresponde.");
                return BadRequest();
            }
            try
            {
                LogManager.Instance.Log($"Atualizando pedido com ID: {id}");
                await _pedidosService.UpdatePedidoAsync(id, pedido);
            }
            catch (KeyNotFoundException)
            {
                LogManager.Instance.Log("Pedido não encontrado para atualização.");
                return NotFound();
            }
            return NoContent();
        }

 
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                LogManager.Instance.Log($"Deletando pedido com ID: {id}");
                await _pedidosService.DeletePedidoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                LogManager.Instance.Log("Pedido não encontrado para exclusão.");
                return NotFound();
            }
            return NoContent();
        }
    }
}
