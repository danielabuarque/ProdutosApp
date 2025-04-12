namespace ProdutosApp.Entities
{
    /// <summary>
    /// Modelo de Entidade para produto
    /// </summary>
    public class Produto
    {
        #region Propriedades 
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public Guid CategoriaId { get; set; }
        #endregion

        #region Relacionamentos
        public Categoria? Categoria { get; set; }
        #endregion
    }
}
