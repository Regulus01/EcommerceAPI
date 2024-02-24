using MediatR;

namespace Domain.Inventario.Commands;

public class CadastrarProdutoCommand : IRequest
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int? Estoque { get; set; }
    public Guid CategoriaId { get; set; }
}