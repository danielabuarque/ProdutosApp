using Microsoft.EntityFrameworkCore;
using ProdutosApp.Mappings;

namespace ProdutosApp.Contexts
{
    /// <summary>
    /// Classe de Context para configuração do Entity Framework
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para configurar o tipo de conexão de dados e adicionar a connectionString(endereço do banco de dados)
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1434;Initial Catalog=master;User ID=sa;Password=Coti@2025;Encrypt=False");
        }

        /// <summary>
        /// Método para adicionar cada classe de mapeamento (Map) feita no projeto
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
