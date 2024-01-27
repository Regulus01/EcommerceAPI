using Application.Inventario.Interface;
using Application.Inventario.ViewModels;
using AutoMapper;
using Domain.Authentication.Inventario.Commands;
using Domain.Authentication.Inventario.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Application.Inventario.AppService;

public class InventarioAppService : IInventarioAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IInventarioRepository _inventarioRepository;

    public InventarioAppService(INotify notify, IMediator mediator, IMapper mapper, IInventarioRepository inventarioRepository)
    {
        _notify = notify.Invoke();
        _mediator = mediator;
        _mapper = mapper;
        _inventarioRepository = inventarioRepository;
    }
    
    public void InserirProdutos(CadastroProdutoViewModel viewModel)
    {
        if (string.IsNullOrEmpty(viewModel.Nome))
        {
            _notify.NewNotification("Erro", "É necessário informado o nome do produto");
            return;
        }

        if (viewModel.Preco <= 0)
        {
            _notify.NewNotification("Erro", "É necessário informar o preço do produto");
            return;
        }

        var command = _mapper.Map<CadastrarProdutoCommand>(viewModel);
        
        _mediator.Send(command);
    }

    public ProdutoViewModel ObterProduto(Guid id)
    {
        var produto = _inventarioRepository.ObterProduto(x => x.Id == id);

        return _mapper.Map<ProdutoViewModel>(produto);
    }
}