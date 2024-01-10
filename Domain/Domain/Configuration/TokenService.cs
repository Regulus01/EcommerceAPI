using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Authentication.Entities;
using Domain.Authentication.Extension;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Authentication.Configuration;

public class TokenService
{
    public TokenModel? GenerateToken (Usuario user)
    {
        //Estancia do manipulador de Token
        var tokenHandler = new JwtSecurityTokenHandler();

        // Método de extensão para gerar as claims do usuário
        var userClaimsAccess = user.GetClaimsAccess().ToList();
        var userClaimsRefresh = user.GetClaimsRefresh().ToList();
        
        //Gerando o token, a partir das claims do usuário
        var accessToken = tokenHandler.CreateToken(GerarToken(8, userClaimsAccess));
        var accessTokenExpiration = accessToken.ValidTo;
        
        var refreshToken = tokenHandler.CreateToken(GerarToken(10, userClaimsRefresh));

        var tokenModel = new TokenModel(tokenHandler.WriteToken(accessToken), accessTokenExpiration, 
                                        tokenHandler.WriteToken(refreshToken));
        
        //Retornando tudo como uma string
        return tokenModel;
    }
    
    
    /// <summary>
    ///  Método responsável por gerar o token do usuário
    /// </summary>
    /// <param name="tempo">Tempo de expiração do token</param>
    /// <param name="userClaims">Claims que irão compor o token</param>
    /// <returns>Token de autenticacao</returns>
    private SecurityTokenDescriptor GerarToken(int tempo, IEnumerable<Claim> userClaims)
    {
        //Chave da classe Configuration. O Token Handler espera um Array de Bytes, por isso é necessário converter
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = "Joestar.com",  // sistema emissor do token
            Audience = "Artemis.Api",
            Subject = new ClaimsIdentity(userClaims), // Claims que vão compor o token
            Expires = DateTime.UtcNow.AddHours(tempo), // Tempo de validade do token
            SigningCredentials = // Assinatura do token, serve para identificar que mandou o
                                //token e garantir que o token não foi alterado no meio do caminho.
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            TokenType = "JWT"
        };

        return tokenDescriptor;
    }
}