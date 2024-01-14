using Application.ViewModels;

namespace Application.Interface;

public interface IAuthorizationAppService
{
    string ObterToken(LoginViewModel? message);
}