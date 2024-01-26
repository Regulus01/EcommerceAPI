namespace Application.Inventario.ViewModels;

public class ProdutoViewModel
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public Guid CategoriaId { get; private set; }
}