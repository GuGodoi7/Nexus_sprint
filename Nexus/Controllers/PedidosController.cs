using _NEXUS.Models;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;
using Nexus.dto;
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
        [ProducesResponseType(typeof(IEnumerable<PedidoResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<PedidoResponseDTO>>> GetPedidos()
        {
            var pedidos = await _pedidosService.GetAllPedidosAsync();

            var pedidosDto = pedidos.Select(p => new PedidoResponseDTO
            {
                IdPedido = p.IdPedido,
                CodigoPedido = p.CodigoPedido,
                Quantidade = p.Quantidade,
                ValorPedido = p.ValorPedido,
                IdUsuario = p.IdUsuario 
            });

            return Ok(pedidosDto);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<PedidoResponseDTO>> GetPedido(int id)
        {
            var pedido = await _pedidosService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }


            var pedidoDto = new PedidoResponseDTO
            {
                IdPedido = pedido.IdPedido,
                CodigoPedido = pedido.CodigoPedido,
                Quantidade = pedido.Quantidade,
                ValorPedido = pedido.ValorPedido,
                IdUsuario = pedido.IdUsuario 
            };

            return Ok(pedidoDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PedidoResponseDTO), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<PedidoResponseDTO>> PostPedido([FromBody] PedidoResponseDTO pedidoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoPedido = new PedidosModel
            {
                CodigoPedido = pedidoDto.CodigoPedido,
                Quantidade = pedidoDto.Quantidade,
                ValorPedido = pedidoDto.ValorPedido,
                IdUsuario = pedidoDto.IdUsuario 
            };

            var createdPedido = await _pedidosService.CreatePedidoAsync(novoPedido);


            var createdPedidoDto = new PedidoResponseDTO
            {
                IdPedido = createdPedido.IdPedido,
                CodigoPedido = createdPedido.CodigoPedido,
                Quantidade = createdPedido.Quantidade,
                ValorPedido = createdPedido.ValorPedido,
                IdUsuario = createdPedido.IdUsuario 
            };

            return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.IdPedido }, createdPedidoDto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PutPedido(int id, [FromBody] PedidoResponseDTO pedidoDto)
        {
            if (id != pedidoDto.IdPedido) 
            {
                return BadRequest();
            }

            var pedidoAtualizado = new PedidosModel
            {
                IdPedido = pedidoDto.IdPedido,
                CodigoPedido = pedidoDto.CodigoPedido,
                Quantidade = pedidoDto.Quantidade,
                ValorPedido = pedidoDto.ValorPedido,
                IdUsuario = pedidoDto.IdUsuario 
            };

            try
            {
                await _pedidosService.UpdatePedidoAsync(id, pedidoAtualizado);
            }
            catch (KeyNotFoundException)
            {
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
