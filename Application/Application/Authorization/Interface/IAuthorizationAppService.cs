using Application.ViewModels;

namespace Application.Interface;

public interface IAuthorizationAppService
{
    TokenViewModel Login(LoginViewModel? message);
    /// <summary>
    /// Método utilizado para cadastrar um usuário no sistema
    /// </summary>
    /// <remarks>
    ///  Método que cadastrar um usuário no sistema, o usuário cadastrado terá por padrão a role de comprador
    /// </remarks>
    /// <param name="viewModel">Dados necessários para o cadastro do usuário</param>
    void CadastrarUsuario(CadastroViewModel viewModel);
}