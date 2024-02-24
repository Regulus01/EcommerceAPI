using Application.Inventario.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Inventario.Controllers;

public partial class ProdutoController
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
    [Route("{id:guid}")]
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
    [AllowAnonymous]
    public IActionResult ObterProdutos([FromQuery] int skip, [FromQuery] int take)
    {
        var response = _appService.Listagem(skip, take);
        
        return ApiResponse(response);
    }

    /// <summary>
    ///    Obtem as arrais de ofertas do dia, promocoes, visualizados e mais vendidos
    /// </summary>
    /// <param name="tipoDaListagemViewModel"></param>
    /// <returns>Lista com produtos</returns>
    [HttpGet]
    [Route("Grid")]
    [AllowAnonymous]
    public IActionResult Grid([FromQuery] TipoDaListagemViewModel tipoDaListagemViewModel)
    {
        var response = _appService.Grid(tipoDaListagemViewModel);
        
        return ApiResponse(response);
    }
}