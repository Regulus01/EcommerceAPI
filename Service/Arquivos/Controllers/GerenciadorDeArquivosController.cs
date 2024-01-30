using Application.Arquivos.Interface;
using Application.Arquivos.ViewModels;
using CrossCutting.Util.Configuration.Core.Controllers;
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

    
    /// <summary>
    /// Método para inserir um arquivo no sistema
    /// </summary>
    /// <param name="arquivo">Campos necessário para inserção do arquivo</param>
    /// <returns>Url do arquivo</returns>
    [HttpPost]
    [Route("GerenciadorDeArquivos")]
    [AllowAnonymous]
    public async Task<IActionResult> EnviarArquivo([FromForm] EnviarGerenciadorDeArquivoViewModel arquivo)
    {
        var response = await _appService.EnviarArquivoS3(arquivo);
        return ApiResponse(response);
    }
}