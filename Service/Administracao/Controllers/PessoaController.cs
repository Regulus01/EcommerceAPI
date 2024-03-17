using Application.Administracao.Interface;
using Application.Administracao.ViewModels;
using CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Administracao.Controllers;

[ApiController]
[Route("api/pessoa/")]
public class PessoaController : CoreController
{
    private IPessoaAppService _appService;
    
    public PessoaController(INotificationHandler<Notifications> notification, IPessoaAppService appService) : base(notification)
    {
        _appService = appService;
    }
    
    /// <summary>
    ///  Cadastra uma pessoa no sistema
    /// </summary>
    /// <returns>Id da pessoa criada</returns>
    [HttpPost]
    [AllowAnonymous]
    public IActionResult CadastrarPessoa([FromBody] CadastrarPessoaViewModel viewModel)
    {
        var response = _appService.CadastrarPessoa(viewModel);
        return ApiResponse(response);
    }
    
}