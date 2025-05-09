using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Entities;

namespace ProdutosApp.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("PRODUTO");

            //chave primária da tabela
            builder.HasKey(p => p.Id);

            //propriedades da tabela produto
            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100).IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("DECIMAL(10,2)").IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(p => p.CategoriaId)
                .HasColumnName("CATEGORIA_ID")
                .IsRequired();

            //Mapeamento do relacionamento e do campo da chave estrangeira
            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
