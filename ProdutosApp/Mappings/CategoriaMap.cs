using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Entities;

namespace ProdutosApp.Mappings
{
    /// <summary>
    /// Classe de Mapeamento ORM para Categoria
    /// </summary>
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA"); //Nome da tabela

            builder.HasKey(c => c.Id); //Chave primária 

            builder.Property(c => c.Id)
                .HasColumnName("ID"); //Como ele se chama no banco de dados

            builder.Property(c => c.Nome)
                .HasColumnName("NOME") //Como ele se chama no banco de dados
                .HasMaxLength(25) //Quantidade máxima de caracteres
                .IsRequired(); //Obrigatório (Not Null)

            builder.HasIndex(c => c.Nome) //Campo que eu não quero que se repita no banco de dados, como por exemplo, duas categorias com nomes iguais
                .IsUnique();
        }
    }
}
