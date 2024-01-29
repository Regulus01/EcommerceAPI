using Application.Arquivos.Interface;
using Application.Arquivos.ViewModels;
using Infra.CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Arquivos.Controllers;

[ApiController]
[Route("api/Arquivo/")]
public class GerenciadorDeArquivosController : CoreController
{
    private IGerenciadorDeArquivoAppService _appService;

    public GerenciadorDeArquivosController(INotificationHandler<Notifications> notification,
        IGerenciadorDeArquivoAppService appService) : base(notification)
    {
        _appService = appService;
    }

    [HttpPost]
    [Route("GerenciadorDeArquivos")]
    [AllowAnonymous]
    public async Task<IActionResult> EnviarArquivo([FromForm] EnviarGerenciadorDeArquivoViewModel arquivo)
    {
        var response = await _appService.EnviarArquivoS3(arquivo);
        return ApiResponse(response);
    }
}