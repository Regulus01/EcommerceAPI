namespace Application.Inventario.ViewModels;

public class CadastroProdutoViewModel
{
    /// <summary>
    /// Nome do produto
    /// </summary>
    public string Nome { get; set; }
    /// <summary>
    /// Valor do produto
    /// </summary>
    public decimal Preco { get; set; }
    
    /// <summary>
    /// Quantidade de produtos em estoque
    /// </summary>
    public int? Estoque { get; set; }
    
    /// <summary>
    /// Id da categoria
    /// </summary>
    public Guid CategoriaId { get; set; }
}