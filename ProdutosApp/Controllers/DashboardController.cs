using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Dtos;
using ProdutosApp.Repositories;

namespace ProdutosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet("categoria-qtdprodutos")]
        public IActionResult GetQtdProdutos()
        {
            var categoriaRepository = new CategoriaRepository();
            var response = categoriaRepository.GroupByQtdProdutos(); //variável que está recebendo o retorno do GroupBy

            return Ok(response);
        }

        [HttpGet("categoria-mediapreco")]
        public IActionResult GetMediaPreco()
        {
            var categoriaRepository = new CategoriaRepository();
            var response = categoriaRepository.GroupByMediaPreco();

            return Ok(response);
        }
    }
}
