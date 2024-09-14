using _NEXUS.Models;
using _NEXUS.Repository;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Nexus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProdutosModel>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> GetProdutos()
        {
            LogManager.Instance.Log("Obtendo todos os produtos.");
            var produtos = await _produtosService.GetAllProdutosAsync();
            return Ok(produtos);
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProdutosModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ProdutosModel>> GetProduto(int id)
        {
            LogManager.Instance.Log($"Obtendo produto com ID: {id}");
            var produto = await _produtosService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                LogManager.Instance.Log("Produto não encontrado.");
                return NotFound();
            }
            return Ok(produto);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ProdutosModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ProdutosModel>> PostProduto([FromBody] ProdutosModel produto)
        {
            LogManager.Instance.Log("Criando novo produto.");
            var createdProduto = await _produtosService.CreateProdutoAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = createdProduto.IdProduto }, createdProduto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PutProduto(int id, [FromBody] ProdutosModel produto)
        {
            if (id != produto.IdProduto)
            {
                LogManager.Instance.Log("ID do produto não corresponde.");
                return BadRequest();
            }
            try
            {
                LogManager.Instance.Log($"Atualizando produto com ID: {id}");
                await _produtosService.UpdateProdutoAsync(id, produto);
            }
            catch (KeyNotFoundException)
            {
                LogManager.Instance.Log("Produto não encontrado para atualização.");
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                LogManager.Instance.Log($"Deletando produto com ID: {id}");
                await _produtosService.DeleteProdutoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                LogManager.Instance.Log("Produto não encontrado para exclusão.");
                return NotFound();
            }
            return NoContent();
        }
    }
}
