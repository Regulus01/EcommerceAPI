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
    /// <returns>Lista com as claims</returns>
    public static IEnumerable<Claim> GetClaimsAccess(this Usuario user)
    {
        var result = new List<Claim>
        {
            new (ClaimTypes.System, user.Id.ToString()),
            new (ClaimTypes.Name, user.Name),
            new (ClaimTypes.Email, user.Email),
        };
        
        return result;
    }
    
    /// <summary>
    /// Método responsável por criar uma lista claims para o refresh token do usuário
    /// </summary>
    /// <remarks>
    ///  Método responsável por criar uma lista de claims para o refresh token do usuário
    ///  baseada nas propriedades especificadas.
    /// </remarks>
    /// <param name="user">Classe que o método de extensão será iniciada</param>
    /// <returns></returns>
    public static IEnumerable<Claim> GetClaimsRefresh(this Usuario user)
    {
        var result = new List<Claim>
        {
            new (ClaimTypes.System, user.Id.ToString()),
        };
        
        return result;
    }
}