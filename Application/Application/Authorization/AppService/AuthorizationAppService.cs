using Application.Interface;
using Application.ViewModels;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;

namespace Application.Authorization.AppService;

public class AuthorizationAppService : IAuthorizationAppService
{
    private readonly Notify _notify;

    public AuthorizationAppService(INotify notify)
    {
        _notify = notify.Invoke();
    }
    
    public string ObterToken(LoginViewModel? message)
    {
        if (string.IsNullOrEmpty(message?.Email) || string.IsNullOrEmpty(message.Password))
        {
            _notify.NewNotification("Erro", "É necessário informar o email e senha");
            return null;
        }

        return "sc";
    }
}