using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Application.Inventario.ViewModels;

public class ProdutoListagemViewModel
{
    public Guid Pro_Id { get; set; }
    
    public string Pro_Nome { get; set; }

    public decimal Pro_Preco { get; set; }
}