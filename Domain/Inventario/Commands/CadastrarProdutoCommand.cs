using MediatR;

namespace Domain.Authentication.Inventario.Commands;

public class CadastrarProdutoCommand : IRequest
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public Guid CategoriaId { get; set; }
}