using System.Text.Json.Serialization;

namespace ProdutosApp.Entities
{
    /// <summary>
    /// Modelo de Entidade para categoria
    /// </summary>
    public class Categoria
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        #endregion

        #region Relacionamentos
        [JsonIgnore]
        public List<Produto>? Produtos { get; set; }
        #endregion
    }
}
