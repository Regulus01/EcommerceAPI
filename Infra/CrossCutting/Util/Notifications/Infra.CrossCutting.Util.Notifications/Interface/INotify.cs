using Infra.CrossCutting.Util.Notifications.Implementation;

namespace Infra.CrossCutting.Util.Notifications.Interface;

public interface INotify
{
    Notify Invoke();
}