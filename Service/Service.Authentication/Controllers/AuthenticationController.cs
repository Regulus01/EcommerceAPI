using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Authentication.Controllers;

[ApiController]
[Route("api/Authentication/")]
public class AuthenticationController : ControllerBase
{

    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "Login")]
    [AllowAnonymous]
    public void ObterTokenDeAutenticacao()
    {
    }
}