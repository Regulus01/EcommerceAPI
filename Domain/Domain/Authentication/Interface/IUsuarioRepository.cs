using System.Linq.Expressions;
using Domain.Authentication.Entities;
using Infra.CrossCutting.Util.Configuration.Core.Repository;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Authentication.Interface;

public interface IUsuarioRepository : IBaseRepository
{
    Usuario? ObterUsuario(Expression<Func<Usuario, bool>> predicate, 
        Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>>? includes = null);
}