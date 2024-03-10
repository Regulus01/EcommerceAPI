using CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Administracao.Controllers;

[ApiController]
[Route("api/administracao/")]
public class AdministracaoController : CoreController
{
    public AdministracaoController(INotificationHandler<Notifications> notification) : base(notification)
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