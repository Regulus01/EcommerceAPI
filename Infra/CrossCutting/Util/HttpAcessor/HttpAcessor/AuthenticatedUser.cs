using Microsoft.AspNetCore.Http;

namespace HttpAcessor;

public class AuthenticatedUser: IAuthenticatedUser
{
    private readonly IHttpContextAccessor _accessor;

    public AuthenticatedUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    /// <summary>
    ///     Método para obter o id do usuário que fez a requisição
    /// </summary>
    /// <returns>Id do usuário no sistema.</returns>
    public Guid? GetUserId()
    {
        var userId = _accessor.HttpContext?.User.Claims.First().Value;
        if(userId != null)
            return Guid.Parse(userId);
        
        return null;
    }
}