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
                    data = result
                });

            return Ok(new
            {
                success = true
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