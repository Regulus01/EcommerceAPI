﻿using Application.Inventario.Interface;
using Application.Inventario.ViewModels;
using Domain.Authentication.Entities.Roles;
using Infra.CrossCutting.Util.Configuration.Core.Controllers;
using Infra.CrossCutting.Util.Notifications.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Inventario.Controllers;

[ApiController]
[Route("api/Inventario/")]
public class InventarioController : CoreController
{
    private IInventarioAppService _appService;

    public InventarioController(INotificationHandler<Notifications> notification, 
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
    [Route("Produto")]
    [Authorize(RoleRegister.Admin.Nome)]
    public IActionResult CadastrarProdutos([FromBody] CadastroProdutoViewModel viewModel)
    {
        _appService.InserirProdutos(viewModel);
        
        return ApiResponse();
    }

    /// <summary>
    ///     EndPoint utilizado para obter um produto do sistema
    /// </summary>
    /// <remarks>
    ///     EndPoint utilizado obter produto especifico
    /// </remarks>
    /// <param name="id">Id do produto</param>
    /// <returns>Produto do sistema</returns>
    [HttpGet]
    [Route("Produto")]
    [AllowAnonymous]
    public IActionResult CadastrarProdutos([FromQuery] Guid id)
    {
        var response = _appService.ObterProduto(id);
        
        return ApiResponse(response);
    }
}