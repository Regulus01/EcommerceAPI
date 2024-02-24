using Application.Inventario.ViewModels;
using Infra.Data.Inventario.DbViewModels;

namespace Application.Inventario.Interface;

public interface IInventarioAppService
{
    /// <summary>
    /// Método para inserir produto no sistema
    /// </summary>
    /// <param name="viewModel">Dados necessários para inserção</param>
    void InserirProdutos(CadastroProdutoViewModel viewModel);

    /// <summary>
    /// Atualiza caminho da foto de capa de um produto
    /// </summary>
    /// <param name="id">Id do produto para atualizacao</param>
    /// <param name="viewModel">Dados necessários para atualizar o caminho de foto</param>
    void AtualizarFotoDeCapa(Guid id, AtualizarCaminhoFotoDeCapaViewModel viewModel);
    
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

    /// <summary>
    /// Obtém a listagem de produtos a partir do tipo informado
    /// </summary>
    /// <param name="tipoDaListagemViewModel"></param>
    /// <returns></returns>
    IEnumerable<ProdutoListagemViewModel> Grid(TipoDaListagemViewModel tipoDaListagemViewModel);
}