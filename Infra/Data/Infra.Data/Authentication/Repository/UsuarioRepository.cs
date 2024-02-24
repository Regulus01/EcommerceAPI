using System.Linq.Expressions;
using Domain.Authentication.Entities;
using Domain.Interface;
using Infra.Core.Base;
using Infra.Data.Authentication.Context;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Authentication.Repository;

public class UsuarioRepository : BaseRepository<AuthenticationContext, UsuarioRepository>, IUsuarioRepository
{
    public UsuarioRepository(AuthenticationContext context, ILogger<UsuarioRepository> logger) : base(context, logger)
    {
    }

    public Usuario? ObterUsuario(Expression<Func<Usuario, bool>> predicate, 
        Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>>? includes = null)
    {
        var query = _context.Users.AsQueryable();

        if (includes != null)
            query = includes(query);

        return query.FirstOrDefault(predicate);
    }
}