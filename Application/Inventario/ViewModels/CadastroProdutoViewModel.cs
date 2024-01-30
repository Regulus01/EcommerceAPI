namespace Application.Inventario.ViewModels;

public class CadastroProdutoViewModel
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public Guid CategoriaId { get; set; }
}