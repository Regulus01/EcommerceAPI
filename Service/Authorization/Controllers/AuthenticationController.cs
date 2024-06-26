using Application.Authorization.ViewModels;
using Application.Interface;
using Application.ViewModels;
using CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Authorization.Controllers;

[ApiController]
[Route("api/authentication/")]
public class AuthenticationController : CoreController
{
    private IAuthorizationAppService _appService;

    public AuthenticationController(INotificationHandler<Notifications> notification,
                                    IAuthorizationAppService appService) : base(notification)
    {
        _appService = appService;
    }

    /// <summary>
    ///     EndPoint utilizado para fazer login no sistema
    /// </summary>
    /// <remarks>
    ///     EndPoint utilizado para realizar o login no sistema a partir do login e senha.
    /// </remarks>
    /// <param name="login">Dados necessários para o login</param>
    /// <returns>Token de autenticação</returns>
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public IActionResult ObterTokenDeAutenticacao(LoginViewModel? login)
    {
        var response = _appService.Login(login);
        
        return ApiResponse(response);
    }
    
    /// <summary>
    /// EndPoint utilizado para cadastrar usuário no sistema
    /// </summary>
    /// <remarks>
    /// EndPoint utilizado para cadastrar usuário no sistema, o usuário cadastrado por padrão terá a role de admin
    /// </remarks>
    /// <param name="viewModel">Dados necessários para o cadastro no sistema</param>
    /// <returns>
    ///  Indicativo se a operação foi bem sucedida
    /// </returns>
    /// <response code="200">Retorna quando o usuário é cadastrado com sucesso</response>
    /// <response code="400">Retorna quando há um erro na requisição ou nos dados fornecidos</response>
    [HttpPost]
    [Route("cadastrar")]
    [AllowAnonymous]
    public async Task<IActionResult> CadastrarUsuario(CadastroViewModel viewModel)
    {
        await _appService.CadastrarUsuario(viewModel);
        
        return ApiResponse();
    }
}