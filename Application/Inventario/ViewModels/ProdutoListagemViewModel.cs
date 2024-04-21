namespace Application.Inventario.ViewModels;

public class ProdutoListagemViewModel
{
    public Guid Id { get; set; }
    
    public string Nome { get; set; }

    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public string FotoDeCapa { get; set; }
    public int Classificacao { get; set; }
}