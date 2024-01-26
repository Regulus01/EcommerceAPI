using Application.Authorization.ViewModels;
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

    /// <summary>
    ///     EndPoint utilizado para fazer login no sistema
    /// </summary>
    /// <remarks>
    ///     EndPoint utilizado para realizar o login no sistema a partir do login e senha.
    /// </remarks>
    /// <param name="login">Dados necessários para o login</param>
    /// <returns>Token de autenticação</returns>
    [HttpPost]
    [Route("Login")]
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
    [Route("Cadastrar")]
    [AllowAnonymous]
    public IActionResult CadastrarUsuario(CadastroViewModel viewModel)
    {
        _appService.CadastrarUsuario(viewModel);
        
        return ApiResponse();
    }
    
    /// <summary>
    ///     EndPoint Authorize utilizado para cadastrar produtos
    /// </summary>
    /// <remarks>
    ///     EndPoint utilizado para cadastrar produtos.
    /// </remarks>
    /// <param name="viewModel">Dados necessários para cadastrar produtos</param>
    /// <returns>objeto com informações sobre a inclusão</returns>
    [HttpPost]
    [Route("Produto")]
    [AllowAnonymous]
    public IActionResult CadastrarProdutos([FromBody] LoginViewModel viewModel)
    {
    
        
        return ApiResponse();
    }
}