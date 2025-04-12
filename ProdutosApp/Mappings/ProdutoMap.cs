using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Entities;

namespace ProdutosApp.Mappings
{
    /// <summary>
    /// Classe de Mapeamento ORM para Produto
    /// </summary>
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO"); //Nome da tabela

            builder.HasKey(p => p.Id); //Chave primária

            builder.Property(p => p.Id)
                .HasColumnName("ID"); //nome do campo

            builder.Property(p => p.Nome) 
                .HasColumnName("NOME") //nome do campo
                .HasMaxLength(150) //Tamanho máximo de caracteres
                .IsRequired(); //Obrigatório (Not Null)

            builder.Property(p => p.Preco)
                 .HasColumnName("PRECO")
                 .HasColumnType("DECIMAL(10,2)") //Tipo de dado e tamanho do campo e numero de casas decimais. Coloca 10 mais desconta as casas decimais.
                 .IsRequired(); //Obrigatório (Not Null)

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired(); //Obrigatório (Not Null)

            builder.Property(p => p.DataCriacao)
                .HasColumnName("DATA_CRIACAO")
                .IsRequired(); //Obrigatório (Not Null)

            builder.Property(p => p.CategoriaId)
                .HasColumnName("CATEGORIA_ID")
                .IsRequired();

            #region Mapeamento do Relacionamento

            builder.HasOne(p => p.Categoria) //PRODUTO tem 1 categoria, se refere ao relacionamento que tem la no Produto
                   .WithMany(c => c.Produtos) //CATEGORIA tem muitos produtos, o produtos é a nossa lista
                   .HasForeignKey(p => p.CategoriaId); //Chave estrangeira do relacionamento
            #endregion

        }
    }
}
