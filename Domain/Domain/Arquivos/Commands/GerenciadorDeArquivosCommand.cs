using Domain.Arquivos.Commands.Events;
using Domain.Arquivos.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Domain.Arquivos.Commands;

public class GerenciadorDeArquivosCommand : IRequest<ArquivoIncluidoEvent?>
{
    public IFormFile Arquivo { get; set; }
    public Guid EntidadeId { get; set; }
    public EntidadeEnum Entidade { get; set; }
    public int Ordem { get; set; }
}