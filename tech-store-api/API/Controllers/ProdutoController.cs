using Microsoft.AspNetCore.Mvc;
using tech_store_api.Application.Services;

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
    }
}
