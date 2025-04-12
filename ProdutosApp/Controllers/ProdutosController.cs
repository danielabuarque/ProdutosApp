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
        [HttpPost] //Annotation to define the HTTP method
        public IActionResult Post([FromBody] ProdutoRequestDto request)
        {
            var produto = new Produto(); //Instanciando produto

            produto.Id = Guid.NewGuid(); //gerando o id do produto
            produto.Nome = request.Nome; //capturando o nome do produto enviado pelo Front
            produto.Preco = request.Preco; //capturando o preço do produto enviado pelo Front
            produto.Quantidade = request.Quantidade; //capturando a quantidade do produto enviado pelo Front
            produto.DataCriacao = DateTime.Now; //capturando a data de criação do produto
            produto.CategoriaId = request.CategoriaId.Value; //capturando o id da categoria do produto enviado pelo Front

            //gravar no banco de dados
            var produtoRepository = new ProdutoRepository();
            produtoRepository.Inserir(produto);

            //retornar mensagem de sucesso
            return Ok(new {Mensagem = "Produto Cadastrado com sucesso."});
        }

        [HttpPut] //Annotation to define the HTTP method
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete] //Annotation to define the HTTP method
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet] //Annotation to define the HTTP method
        public IActionResult Get([FromQuery] string nome)
        {
            //instanciando a classe de repositório
            var produtoRepository = new ProdutoRepository();

            //executando a consulta de produtos por nome
            var produtos = produtoRepository.ConsultarPorNome(nome);

            //retornando os dados da consulta
            return Ok(produtos);
        }
    }
}
