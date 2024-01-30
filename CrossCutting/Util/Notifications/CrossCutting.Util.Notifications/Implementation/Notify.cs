using Infra.CrossCutting.Util.Notifications.Handler;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;
using NotificationsModel = Infra.CrossCutting.Util.Notifications.Model.Notifications;

namespace Infra.CrossCutting.Util.Notifications.Implementation;

public class Notify : INotify
{
    private readonly NotifyHandler _messageHandler;

    public Notify(INotificationHandler<NotificationsModel> notification)
    {
        _messageHandler = (NotifyHandler) notification;
    }

    public Notify Invoke()
    {
        return this;
    }

    public bool HasNotifications()
    {
        return !_messageHandler.HasNotifications();
    }

    public void NewNotification(string key, string message)
    {
        _messageHandler.Handle(new NotificationsModel(key, message), default(CancellationToken));
    }
}