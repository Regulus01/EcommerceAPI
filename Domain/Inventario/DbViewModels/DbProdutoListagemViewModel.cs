namespace Infra.Data.Inventario.DbViewModels;

public class DbProdutoListagemViewModel
{
    public Guid Pro_Id { get; set; }
    
    public string Pro_Nome { get; set; }
    public int Pro_Estoque { get; set; }

    public decimal Pro_Preco { get; set; }
}