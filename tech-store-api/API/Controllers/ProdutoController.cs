using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using tech_store_api.Application.Services;
using tech_store_api.Domain.Entities;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _service.ObterProdutos();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Produto inv�lido.");

            var novoProduto = _service.CriarProduto(produto);

            return CreatedAtAction(nameof(Get), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _service.ObterProdutoPorId(id);
            if (produto == null)
                return NotFound();

            _service.RemoverProduto(id);

            return NoContent();
        }
    }
}
