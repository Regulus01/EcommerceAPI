using Application.Inventario.Interface;
using Application.Inventario.ViewModels;
using CrossCutting.Util.Configuration.Core.Controllers;
using Domain.Authentication.Entities.Roles;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Inventario.Controllers;

[ApiController]
[Route("api/Produto/")]
public partial class ProdutoController : CoreController
{
    private IInventarioAppService _appService;

    public ProdutoController(INotificationHandler<Notifications> notification, 
        IInventarioAppService appService) : base(notification)
    {
        _appService = appService;
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
    [Authorize(RoleRegister.Admin.Nome)]
    public IActionResult CadastrarProdutos([FromBody] CadastroProdutoViewModel viewModel)
    {
        _appService.InserirProdutos(viewModel);
        
        return ApiResponse();
    }
}