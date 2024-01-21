using System.Linq.Expressions;
using Domain.Authentication.Entities;
using Domain.Authentication.Interface;
using Infra.Data.Authentication.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Authentication.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AuthenticationContext _context;
    private readonly ILogger<UsuarioRepository> _logger;
    
    public UsuarioRepository(AuthenticationContext context, ILogger<UsuarioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Usuario? ObterUsuario(Expression<Func<Usuario, bool>> predicate, Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>>? includes = null)
    {
        var query = _context.Users.AsQueryable();

        if (includes != null)
            query = includes(query);

        return query.FirstOrDefault(predicate);
    }
    
    public void AdicionarUsuario(Usuario usuario)
    {
        _context.Add(usuario);
    }
    
    public void AdicionarRole(UsuarioRole usuarioRole)
    {
        _context.UsuarioRoles.Add(usuarioRole);
    }
    
    public bool Commit()
    {
        try
        {
            var result = _context.SaveChanges();
            return result > 1;
        }
        catch (Exception e)
        {
            _logger.LogInformation("Erro ao commitar entidades no banco de dados: {error}", e.Message);
            return false;
        }
    }
}