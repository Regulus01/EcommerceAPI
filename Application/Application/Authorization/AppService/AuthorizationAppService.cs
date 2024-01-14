using Application.Interface;
using Application.ViewModels;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;

namespace Application.AppService;

public class AuthorizationAppService : IAuthorizationAppService
{
    private readonly Notify _notify;

    public AuthorizationAppService(INotify notify)
    {
        _notify = notify.Invoke();
    }
    
    public string ObterToken(LoginViewModel? message)
    {
        if (string.IsNullOrEmpty(message.Email))
        {
            _notify.NewNotification("Erro", "É necessário preencher o email");
            return "teste";
        }

        return "sc";
    }
}