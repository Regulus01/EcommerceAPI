using Application.Inventario.Interface;
using Application.Inventario.ViewModels;
using Infra.CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Authorization.Controllers;

[ApiController]
[Route("api/Inventario/")]
public class InventarioController : CoreController
{
    
    private IIventarioAppService _appService;
    
    public InventarioController(INotificationHandler<Notifications> notification) : base(notification)
    {
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
    public IActionResult CadastrarProdutos([FromBody] ProdutoViewModel viewModel)
    {
        _appService.InserirProdutos(viewModel);
        
        return ApiResponse();
    }
}