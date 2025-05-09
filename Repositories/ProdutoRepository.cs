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
        /// <param name="produto"></param>
        public void Inserir(Produto produto)
        {
            //abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar um produto no banco de dados
        /// </summary>
        /// <param name="produto"></param>
        public void Atualizar(Produto produto)
        {
            //abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para excluir um produto no banco de dados
        /// </summary>
        /// <param name="produto"></param>
        public void Excluir(Produto produto)
        {
            //abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para consultar um produto por Id
        /// </summary>
        public Produto? ObterPorId(Guid id)
        {
            //abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>()
                        .Where(p => p.Id == id)
                        .FirstOrDefault();
            }
        }

        /// <summary>
        /// Método para consultar produtos que contenham um nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<Produto> ConsultaPorNome(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>()
                           .Include(p => p.Categoria) 
                           .Where(p => p.Nome.Contains(nome))
                           .OrderBy(p => p.Nome)
                           .ToList();
            }
        }
    }
}
