using Application.ViewModels;

namespace Application.Interface;

public interface IAuthorizationAppService
{
    void ObterToken(LoginViewModel? message);
}