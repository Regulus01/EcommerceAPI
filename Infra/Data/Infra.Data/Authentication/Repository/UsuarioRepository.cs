using Domain.Authentication.Entities;
using Domain.Authentication.Interface;
using Infra.Data.Authentication.Context;
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
    
    public bool EmailCadastrado(string email)
    {
        var emailExiste = _context.Users.FirstOrDefault(x => x.Email == email);
        
        return emailExiste != null;
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