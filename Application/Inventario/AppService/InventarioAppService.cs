using Application.Inventario.Interface;
using Application.Inventario.ViewModels;
using AutoMapper;
using Domain.Inventario.Commands;
using Domain.Inventario.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Application.Inventario.AppService;

public class InventarioAppService : IInventarioAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProdutoRepository _produtoRepository;

    public InventarioAppService(INotify notify, IMediator mediator, IMapper mapper, IProdutoRepository produtoRepository)
    {
        _notify = notify.Invoke();
        _mediator = mediator;
        _mapper = mapper;
        _produtoRepository = produtoRepository;
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

    public void AtualizarFotoDeCapa(Guid id, AtualizarCaminhoFotoDeCapaViewModel viewModel)
    {
        if (string.IsNullOrEmpty(viewModel.CaminhoFotoDeCapa))
        {
            _notify.NewNotification("Erro", "É necessário informar o a foto de capa");
            return;
        }
        
        if (id == Guid.Empty)
        {
            _notify.NewNotification("Erro", "É necessário informar o a foto de capa");
            return;
        }
        
        var command = _mapper.Map<CaminhoFotoCapaCommand>(viewModel);
        command.Id = id;
        
        _mediator.Send(command);
    }

    public ProdutoViewModel? ObterProduto(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            _notify.NewNotification("Erro", "Id não informado");
            return null;
        }
        
        var produto = _produtoRepository.ObterProduto(x => x.Id == id);

        return _mapper.Map<ProdutoViewModel>(produto);
    }

    public IEnumerable<ProdutoListagemViewModel> Listagem(int skip, int take)
    {
        if (skip < 0)
        {
            _notify.NewNotification("Erro", "Inicio da listagem não pode ser menor 0");
            return new List<ProdutoListagemViewModel>();
        }
        
        if (take <= 0)
        {
            _notify.NewNotification("Erro", "Tamanho da listagem não pode ser 0");
            return new List<ProdutoListagemViewModel>();
        }
        
        var produtos = _produtoRepository.Listagem(skip, take);
        
        return _mapper.Map<IEnumerable<ProdutoListagemViewModel>>(produtos);;
    }
}