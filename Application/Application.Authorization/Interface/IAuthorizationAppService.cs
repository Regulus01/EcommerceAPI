using Application.Authorization.ViewModels;

namespace Application.Authorization.Interface;

public interface IAuthorizationAppService
{
    void ObterToken(LoginViewModel? message);
}