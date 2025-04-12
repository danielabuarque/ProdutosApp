using Microsoft.EntityFrameworkCore;
using ProdutosApp.Contexts;
using ProdutosApp.Entities;

namespace ProdutosApp.Repositories
{
    public class ProdutoRepository
    {
        /// <summary>
        /// Método para inserir um produto no banco de dados
        /// </summary>
        public void Inserir(Produto produto)
        {
            //Conectando no banco de dados através do Entity Framework
            using (var dataContext = new DataContext() )
            {
                dataContext.Add(produto); //Escrevendo o comando INSERT para gravar o produto. Promessa do que eu quero que ele faça
                dataContext.SaveChanges(); //Executando a gravação do produto no banco de dados
            }
        }

        /// <summary>
        /// Método para atualizar um produto no banco de dados
        /// </summary>
        public void Atualizar(Produto produto)
        {
            //Conectando no banco de dados através do Entity Framework
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto); //Escrevendo o comando UPDATE para atualizar o produto. Promessa do que eu quero que ele faça
                dataContext.SaveChanges(); //Executando a atualização do produto no banco de dados
            }
        }

        /// <summary>
        /// Método para excluir um produto no banco de dados
        /// </summary>
        public void Excluir(Produto produto)
        {
            //Conectando no banco de dados através do Entity Framework
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(produto); //Escrevendo o comando DELETE para excluir o produto
                dataContext.SaveChanges(); //Executando a exclusão do produto no banco de dados
            }
        }

        /// <summary>
        /// Método para consultar produtos no banco de dados filtrando pelo nome, ou seja, contendo o nome passado no método.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<Produto> Consultar(string nome)
        {
            //Conectando no banco de dados através do Entity Framework
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>() //consultando dados de produtos
                        .Where(p => p.Nome.Contains(nome)) // filtro: nome contenha o valor passado
                        .OrderBy(p => p.Nome) //ordenação: ordem alfabética do campo nome
                        .ToList(); //finalizando a consulta e retornando a lista de produtos obtidos
            }
        }

        public Produto? ObterPorId(Guid id)
        {
            //Conectando no banco de dados através do Entity Framework
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>() //consultando dados de produto
                    .Where(p => p.Id == id) //filtro: id igual ao valor passado
                    .FirstOrDefault(); //Finalizando a consulta e retornando o primeiro registro encontrado e se nenhum registro for encontrado, ele retorna null
            }
        }

        //Método para consultar todos os produtos que contenham um determinado nome
        public List<Produto> ConsultarPorNome(string nome)
        {
            //abrindo conexão com o bando de dados através do EntityFramework
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>() //consultando os dados da entidade produto
                        .Include(p => p.Categoria) //incluindo os dados da categoria do produto
                        .Where(p => p.Nome.Contains(nome)) //filtrando o produto pelo nome
                        .OrderBy(p => p.Nome) //ordem alfabética de nome
                        .ToList(); //retornar uma lista com todos os produtos encontrados
            }
        }


    }
}
