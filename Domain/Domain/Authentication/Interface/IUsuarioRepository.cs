using System.Linq.Expressions;
using Domain.Authentication.Entities;
using Domain.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Interface;

public interface IUsuarioRepository : IBaseRepository
{
    /// <summary>
    /// Obtém o usuário a partir de um predicate
    /// </summary>
    /// <param name="predicate">predicate da operação</param>
    /// <param name="includes">includes</param>
    /// <returns>Usuário correspondente ao predicate</returns>
    Usuario? ObterUsuario(Expression<Func<Usuario, bool>> predicate, 
        Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>>? includes = null);
}