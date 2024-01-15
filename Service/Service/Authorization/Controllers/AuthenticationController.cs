using Application.Interface;
using Application.ViewModels;
using Infra.CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Authorization.Controllers;

[ApiController]
[Route("api/Authentication/")]
public class AuthenticationController : CoreController
{
    private IAuthorizationAppService _appService;

    public AuthenticationController(INotificationHandler<Notifications> notification,
                                    IAuthorizationAppService appService) : base(notification)
    {
        _appService = appService;
    }

    [HttpPost(Name = "Login")]
    [AllowAnonymous]
    public IActionResult ObterTokenDeAutenticacao(LoginViewModel? login)
    {
        var response = _appService.ObterToken(login);
        
        return ApiResponse(response);
    }
}