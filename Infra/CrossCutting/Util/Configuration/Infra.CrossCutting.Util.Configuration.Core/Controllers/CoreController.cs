using System.Net;
using Infra.CrossCutting.Util.Configuration.Core.Response;
using Infra.CrossCutting.Util.Notifications.Handler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Infra.CrossCutting.Util.Configuration.Core.Controllers;

public abstract class CoreController : ControllerBase
{
    private readonly NotifyHandler _notifications;

    protected CoreController(INotificationHandler<Notifications.Model.Notifications> notification)
    {
        _notifications = (NotifyHandler)notification;
    }

    protected IActionResult CreatedHasNotification(string route, object result = null)
    {
        if (!HasNotifications())
        {
            if (result != null)
                return Created(route, new
                {
                    success = true,
                    data = result
                });

            return Created(route, new
            {
                success = true
            });
        }

        return NoticationsEntity();
    }

    protected bool HasNotifications()
    {
        return _notifications.HasNotifications();
    }

    protected IActionResult NoticationsEntity()
    {
        var notifications =
            _notifications.GetNotifications();

        if (notifications.Any())
        {
            return BadRequest(new ApiResponse(HttpStatusCode.BadRequest.ToString(), notifications.ToList()));
        }

        return BadRequest(new ApiResponse(HttpStatusCode.BadRequest.ToString(), notifications.ToList()));
    }
}