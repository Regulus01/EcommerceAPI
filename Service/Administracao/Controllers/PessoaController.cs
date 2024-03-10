using Application.Administracao.Interface;
using CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Administracao.Controllers;

[ApiController]
[Route("api/pessoa/")]
public class PessoaController : CoreController
{
    private IPessoaAppService _appService;
    
    public PessoaController(INotificationHandler<Notifications> notification) : base(notification)
    {
    }
    /*
    /// <summary>
    ///  Cadastra uma pessoa no sistema
    /// </summary>
    /// <returns>Url do arquivo</returns>
    [HttpPost]
    [Route(("pessoa"))]
    public async Task<IActionResult> CadastrarPessoa([FromForm] EnviarGerenciadorDeArquivoViewModel arquivo)
    {
        var response = await _appService.EnviarArquivoS3(arquivo);
        return ApiResponse(response);
    }*/
    
}