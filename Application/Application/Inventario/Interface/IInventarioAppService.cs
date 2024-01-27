﻿using Application.Inventario.ViewModels;

namespace Application.Inventario.Interface;

public interface IInventarioAppService
{
    /// <summary>
    /// Método para inserir produto no sistema
    /// </summary>
    /// <param name="viewModel">Dados necessários para inserção</param>
    void InserirProdutos(CadastroProdutoViewModel viewModel);

    /// <summary>
    /// Método para obter um produto do sistema
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Produto</returns>
    ProdutoViewModel? ObterProduto(Guid id);

    /// <summary>
    /// Método para obter uma listagem de produtos
    /// </summary>
    /// <param name="skip">Inicio da listagem</param>
    /// <param name="take">Tamanho da listagem</param>
    /// <returns>Lista com produtos</returns>
    IEnumerable<ProdutoListagemViewModel> Listagem(int skip, int take);
}