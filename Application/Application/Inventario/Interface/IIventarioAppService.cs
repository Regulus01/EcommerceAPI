using Application.Inventario.ViewModels;

namespace Application.Inventario.Interface;

public interface IIventarioAppService
{
    void InserirProdutos(ProdutoViewModel viewModel);
}