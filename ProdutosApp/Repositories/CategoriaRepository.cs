using Microsoft.EntityFrameworkCore;
using ProdutosApp.Contexts;
using ProdutosApp.Dtos;
using ProdutosApp.Entities;

namespace ProdutosApp.Repositories
{
    public class CategoriaRepository
    {
        /// <summary>
        /// Método para consultar todas as categorias cadastradas na tabela do banco de dados
        /// </summary>
        /// <returns></returns>
        public List<Categoria> Consultar()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                       .Set<Categoria>()  //consultando dados de categoria
                       .OrderBy(c => c.Nome) //ordenação: ordem alfabética do campo nome
                       .ToList(); //retornar uma lista de categorias como resultado
            }
        }

        //Método que retorne o somatório da quantidade de produtos por
        //cada categoria, usando uma função GRUP BY do banco de dados
        public List<CategoriaQtdProdutosResponseDto> GroupByQtdProdutos()
        {
            //abrindo conexão com o banco de dados através do EntityFramework
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>()
                        .Include(p => p.Categoria) //junção (JOIN) com a entidade categoria
                        .GroupBy(c => c.Categoria.Nome) //agrupando pelo nome da categoria
                        .Select(g => new CategoriaQtdProdutosResponseDto
                        {
                            Categoria = g.Key,
                            QtdProdutos = g.Sum(p => p.Quantidade.Value)
                        })
                        .OrderByDescending(dto => dto.QtdProdutos)
                        .ToList();
            }
        }

        //Método que retorne a média de preços de produtos por
        //cada categoria, usando uma função GRUP BY do banco de dados
        public List<CategoriaMediaPrecoResponseDto> GroupByMediaPreco()
        {
            //abrindo conexão com o banco de dados através do EntityFramework
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>()
                        .Include(p => p.Categoria) //junção (JOIN) com a entidade categoria
                        .GroupBy(c => c.Categoria.Nome) //agrupando pelo nome da categoria
                        .Select(g => new CategoriaMediaPrecoResponseDto
                        {
                            Categoria = g.Key,
                            MediaPreco = g.Average(p => p.Preco)
                        })
                        .OrderByDescending(dto => dto.MediaPreco)
                        .ToList();
            }
        }


    }
}
