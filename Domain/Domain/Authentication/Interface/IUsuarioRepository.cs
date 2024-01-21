using System.Linq.Expressions;
using Domain.Authentication.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Authentication.Interface;

public interface IUsuarioRepository
{
    public Usuario? ObterUsuario(Expression<Func<Usuario, bool>> predicate, Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>>? includes = null);
    public void AdicionarUsuario(Usuario usuario);
    public void AdicionarRole(UsuarioRole usuarioRole);

    bool Commit();
}