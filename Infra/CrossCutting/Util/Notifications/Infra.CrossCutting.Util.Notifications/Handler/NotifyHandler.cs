using MediatR;
using NotificationsModel = Infra.CrossCutting.Util.Notifications.Model.Notifications;

namespace Infra.CrossCutting.Util.Notifications.Handler;

public class NotifyHandler : INotificationHandler<NotificationsModel>
{
    private List<NotificationsModel> _notifications;

    public NotifyHandler()
    {
        _notifications = new List<NotificationsModel>();
    }
    
    public Task Handle(NotificationsModel notification, CancellationToken cancellationToken)
    {
        _notifications.Add(notification);
        return Task.CompletedTask;
    }

    public virtual List<NotificationsModel> GetNotifications()
    {
        return _notifications.Where(not => not.GetType() == typeof(NotificationsModel))
                             .ToList();
    }

    public virtual bool HasNotifications()
    {
        return GetNotifications().Any();
    }

    public void Dispose()
    {
        _notifications = new List<NotificationsModel>();
    }
}