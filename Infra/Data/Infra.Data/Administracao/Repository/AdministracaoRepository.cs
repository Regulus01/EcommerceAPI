using Infra.Core.Base;
using Infra.Data.Administracao.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Administracao.Repository;

public class AdministracaoRepository : BaseRepository<AdministracaoContext, AdministracaoRepository> 
{
    public AdministracaoRepository(AdministracaoContext context, ILogger<AdministracaoRepository> logger) : base(context, logger)
    {
    }
}