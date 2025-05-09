using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Dtos;
using ProdutosApp.Entities;
using ProdutosApp.Repositories;

namespace ProdutosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        /// <summary>
        /// Método para consulta de produtos
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok();
        //}

        /// <summary>
        /// Serviço para cadastro de produto na API
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequestDto request)
        {
            var produto = new Produto();
            produto.Id = Guid.NewGuid();
            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Quantidade = request.Quantidade;
            produto.CategoriaId = request.CategoriaId;

            //gravar esse produto no banco de dados
            var produtoRepository = new ProdutoRepository();
            produtoRepository.Inserir(produto);

            return Ok(new { Mensagem = "Produto cadastrado com sucesso."});
        }

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        /// <summary>
        /// Método para excluir um produto
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string nome)
        {
            var produtoRepository = new ProdutoRepository();
            var produtos = produtoRepository.ConsultaPorNome(nome);

            return Ok(produtos);
        }
    }

}
