using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Entities;

namespace ProdutosApp.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //Nome da tabela
            builder.ToTable("CATEGORIA");

            //CHAVE Primária
            builder.HasKey(c => c.Id);

            //propriedades
            builder.Property(c => c.Id).HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            //Coluna nome não pode permitir valores duplicados
            builder.HasIndex(c => c.Nome).IsUnique();
        }
    }
}
