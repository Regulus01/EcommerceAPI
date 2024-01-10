using Infra.CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[ApiController]
[Route("api/Authentication/")]
public class AuthenticationController : CoreController
{

    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(INotificationHandler<Notifications> notification, 
        ILogger<AuthenticationController> logger) : base(notification)
    {
        _logger = logger;
    }

    [HttpPost(Name = "Login")]
    [AllowAnonymous]
    public void ObterTokenDeAutenticacao()
    {
    }
}