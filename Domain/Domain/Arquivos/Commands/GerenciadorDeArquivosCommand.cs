using Enums.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Domain.Arquivos.Commands;

public class GerenciadorDeArquivosCommand : IRequest
{
    public IFormFile Arquivo { get; set; }
    public Guid EntidadeId { get; set; }
    public Tabela Entidade { get; set; }
    public int Ordem { get; set; }
}