using _NEXUS.Models;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> GetProdutos()
        {
            var produtos = await _produtosService.GetAllProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> GetProduto(int id)
        {
            var produto = await _produtosService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> PostProduto([FromForm] ProdutosModel produto)
        {
            var createdProduto = await _produtosService.CreateProdutoAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = createdProduto.IdProduto }, createdProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, [FromForm] ProdutosModel produto)
        {
            if (id != produto.IdProduto)
            {
                return BadRequest();
            }
            try
            {
                await _produtosService.UpdateProdutoAsync(id, produto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtosService.DeleteProdutoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
