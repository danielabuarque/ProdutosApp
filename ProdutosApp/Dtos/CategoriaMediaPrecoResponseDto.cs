namespace ProdutosApp.Dtos
{
    /// <summary>
    /// Modelo de ados da consulta média de preços de produtos por cada categoria
    /// </summary>
    public class CategoriaMediaPrecoResponseDto
    {
        public string? Categoria { get; set; }
        public decimal? MediaPreco { get; set; }
    }
}
