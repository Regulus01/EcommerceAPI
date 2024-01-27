﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Inventario.Controllers;

public partial class InventarioController
{
    
    /// <summary>
    ///     EndPoint utilizado para obter um produto do sistema
    /// </summary>
    /// <remarks>
    ///     EndPoint utilizado obter produto especifico
    /// </remarks>
    /// <param name="id">Id do produto</param>
    /// <returns>Produto do sistema</returns>
    [HttpGet]
    [Route("Produto/{id:guid}")]
    [AllowAnonymous]
    public IActionResult CadastrarProdutos([FromRoute] Guid id)
    {
        var response = _appService.ObterProduto(id);
        
        return ApiResponse(response);
    }
    
    /// <summary>
    /// EndPoint utilizado para obter uma listagem de produtos
    /// </summary>
    /// <param name="skip">Inicio da listagem</param>
    /// <param name="take">Tamanho da listagem</param>
    /// <returns>Lista com produtos</returns>
    [HttpGet]
    [Route("Produto")]
    [AllowAnonymous]
    public IActionResult ObterProdutos([FromQuery] int skip, [FromQuery] int take)
    {
        var response = _appService.Listagem(skip, take);
        
        return ApiResponse(response);
    }
}