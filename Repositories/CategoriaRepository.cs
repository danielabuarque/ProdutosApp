using ProdutosApp.Contexts;
using ProdutosApp.Entities;

namespace ProdutosApp.Repositories
{
    public class CategoriaRepository
    {
        /// <summary>
        /// Método para consultar todas as categorias no banco de dados
        /// </summary>
        public List<Categoria> Consultar()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Categoria>()
                        .OrderBy(c => c.Nome)
                        .ToList();
            }
        }
    }
}
