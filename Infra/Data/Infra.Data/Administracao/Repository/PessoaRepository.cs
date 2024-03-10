using Domain.Administracao.Interfaces;
using Infra.Core.Base;
using Infra.Data.Administracao.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Administracao.Repository;

public class PessoaRepository : BaseRepository<AdministracaoContext, PessoaRepository>, IPessoaRepository
{
    public PessoaRepository(AdministracaoContext context, ILogger<PessoaRepository> logger) : base(context, logger)
    {
    }
}