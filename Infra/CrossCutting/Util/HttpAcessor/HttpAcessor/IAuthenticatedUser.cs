namespace HttpAcessor;

public interface IAuthenticatedUser
{
    /// <summary>
    ///     Método para obter o id do usuário que fez a requisição
    /// </summary>
    /// <returns>Id do usuário no sistema.</returns>
    Guid? GetUserId();
}