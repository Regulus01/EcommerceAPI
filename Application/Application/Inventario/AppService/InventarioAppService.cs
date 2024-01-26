using Application.Inventario.Interface;
using Application.Inventario.ViewModels;
using AutoMapper;
using Domain.Authentication.Interface;
using Domain.Authentication.Inventario.Commands;
using Infra.CrossCutting.Util.Notifications.Implementation;
using MediatR;

namespace Application.Inventario.AppService;

public class InventarioAppService : IIventarioAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public void InserirProdutos(ProdutoViewModel viewModel)
    {
        if (string.IsNullOrEmpty(viewModel.Nome))
        {
            _notify.NewNotification("Erro", "É necessário informado o nome do produto");
            return;
        }

        if (viewModel.Preco <= 0)
        {
            _notify.NewNotification("Erro", "É informar o preço do produto");
            return;
        }

        var command = _mapper.Map<CadastrarProdutoCommand>(viewModel);
        
        _mediator.Send(command);
    }
}