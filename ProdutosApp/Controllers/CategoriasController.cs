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
        /// Serviço da API para retornar uma consulta de categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Criando um objeto da classe repositório
            var categoriaRepository = new CategoriaRepository();

            //Executando a consulta de categorias e armazenando o resultado (lista de categorias) em uma variável
            var categorias = categoriaRepository.Consultar();

            return Ok(categorias); //Vou devolver a lista para quem pediu ela. Quem vai pedir? O front, o angular. E ele vai devolver como json porque estamos no ApiController. Ele entende que ele é um barramento do controle de API.
        }
    }
}
