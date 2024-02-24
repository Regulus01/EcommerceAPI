using MediatR;

namespace Domain.Inventario.Commands;

public class CaminhoFotoCapaCommand : IRequest
{
    public Guid Id { get; set; }
    public string CaminhoFotoDeCapa { get; set; }
}