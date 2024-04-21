namespace Domain.Inventario.DbViewModels;

public class DbProdutoListagemViewModel
{
    public Guid Id { get; set; }
    
    public string Pro_Nome { get; set; }
    public int Pro_Estoque { get; set; }

    public decimal Pro_Preco { get; set; }
    public string Ger_CaminhoFotoDeCapa { get; set; }
    public int Pro_Classificacao { get; set; }
}