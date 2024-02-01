using Application.Inventario.Interface;
using Application.Inventario.ViewModels;
using CrossCutting.Util.Configuration.Core.Controllers;
using Domain.Authentication.Entities.Roles;
using Domain.Entities.Roles;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Inventario.Controllers;

[ApiController]
[Route("api/produto/")]
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

    /// <summary>
    ///     EndPoint Authorize para atualizar foto de capa do produto.
    /// </summary>
    /// <remarks>
    ///     EndPoint Authorize para atualizar foto de capa do produto.
    /// </remarks>
    /// <param name="id">Id do produto para atualização</param>
    /// <param name="viewModel">Dados necessários atualizar a foto de capa de um produto</param>
    [HttpPatch]
    [Route("{id:guid}/fotodecapa")]
    [Authorize(RoleRegister.Admin.Nome)]
    public IActionResult AtualizarFotoDeCapa([FromRoute] Guid id, [FromBody] AtualizarCaminhoFotoDeCapaViewModel viewModel)
    {
        _appService.AtualizarFotoDeCapa(id, viewModel);
        
        return ApiResponse();
    }
}