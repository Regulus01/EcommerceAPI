using Domain.Arquivos.Interfaces;
using Infra.CrossCutting.Util.Configuration.Core.Repository;
using Infra.Data.Arquivos.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Arquivos.Repository;

public class GerenciadorDeArquivosRepository : BaseRepository<GerenciadorDeArquivosContext, GerenciadorDeArquivosRepository>, 
    IGerenciadorDeArquivosRepository
{
    public GerenciadorDeArquivosRepository(GerenciadorDeArquivosContext context, ILogger<GerenciadorDeArquivosRepository> logger) 
        : base(context, logger)
    {
    }
}