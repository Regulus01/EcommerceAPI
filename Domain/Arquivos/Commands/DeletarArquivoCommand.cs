using MediatR;

namespace Domain.Arquivos.Commands;

public class DeletarArquivoCommand : IRequest
{
    public Guid Id { get; set; }
    
    public DeletarArquivoCommand(Guid id)
    {
        Id = id;
    }
}