using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Repositories;

namespace ProdutosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        /// <summary>
        /// Método para consultar as categorias da API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var categoriaRepository = new CategoriaRepository();
            var categorias = categoriaRepository.Consultar();

            return Ok(categorias);
        }
    }
}
