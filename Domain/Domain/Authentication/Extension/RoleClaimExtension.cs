using System.Security.Claims;
using Domain.Authentication.Entities;

namespace Domain.Authentication.Extension;

public static class RoleClaimExtension
{
    /// <summary>
    ///  Método responsável por criar uma lista de claims para o token do usuário.
    /// </summary>
    /// <remarks>
    ///  Método responsável por criar uma lista de claims, baseado nas propriedades
    ///  especificadas do usuário. Essas claims principais serão utilizadas pelo token de
    ///  authorização
    /// </remarks>
    /// <param name="user">Classe que o método de extensão será iniciada</param>
    /// <returns>Lista com as claims que vão compor o token</returns>
    public static IEnumerable<Claim> GetClaimsAccess(this Usuario user)
    {
        var userRoles = user.UsuarioRoles.Select(role => role.Role.Nome).ToList();
        
        if (userRoles.Count == 0)
            return new List<Claim>();
       
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.Nome),
            new (ClaimTypes.Email, user.Email)
        };

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        return claims;
    }
    
    /// <summary>
    /// Método responsável por criar uma lista claims para o refresh token do usuário
    /// </summary>
    /// <remarks>
    ///  Método responsável por criar uma lista de claims para o refresh token do usuário
    ///  baseada nas propriedades especificadas.
    /// </remarks>
    /// <param name="user">Classe que o método de extensão será iniciada</param>
    /// <returns>Lista com as claims que vao compor o RefreshToken</returns>
    public static IEnumerable<Claim> GetClaimsRefresh(this Usuario user)
    {
        var result = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
        };
        
        return result;
    }
}