using System.Net;
using CrossCutting.Util.Configuration.Core.Response;
using Infra.CrossCutting.Util.Notifications.Handler;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossCutting.Util.Configuration.Core.Controllers;

public abstract class CoreController : ControllerBase
{
    private readonly NotifyHandler _notifications;

    protected CoreController(INotificationHandler<Notifications> notification)
    {
        _notifications = (NotifyHandler) notification;
    }

    protected IActionResult ApiResponse(object? result = null)
    {
        if (!HasNotifications())
        {
            if (result != null)
                return Ok(new
                {
                    success = true,
                    time = DateTimeOffset.UtcNow,
                    data = result
                });

            return Ok(new
            {
                success = true,
                time = DateTimeOffset.UtcNow
            });
        }

        return NoticationsEntity();
    }

    private bool HasNotifications()
    {
        return _notifications.HasNotifications();
    }

    private IActionResult NoticationsEntity()
    {
        var notifications = _notifications.GetNotifications();

        return BadRequest(new ApiResponse(HttpStatusCode.BadRequest.ToString(), notifications.ToList()));
    }
}