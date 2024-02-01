using AutoMapper;
using Domain.Inventario.Entities;
using Domain.Inventario.Commands;
using Domain.Inventario.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Domain.Inventario.Handle;

public class ProdutoCommandHandler : IRequestHandler<CadastrarProdutoCommand>,
                                     IRequestHandler<CaminhoFotoCapaCommand> 
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;
    private readonly Notify _notify;

    public ProdutoCommandHandler(IProdutoRepository produtoRepository, IMapper mapper, INotify notify)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
        _notify = notify.Invoke();
    }
    
    public Task Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = _mapper.Map<Produto>(request);

        produto.InformeCaminhoFotoDeCapa(
            "https://arquivosprojetomarketplace.s3.us-east-2.amazonaws.com/Produto/caixa-1.png");
        
        _produtoRepository.Add(produto);
        
        if (!_produtoRepository.Commit())
        {
            _notify.NewNotification("Erro", "Erro ao inserir dados");
            return Task.FromResult(cancellationToken);
        }

        return Task.CompletedTask;
    }

    public Task Handle(CaminhoFotoCapaCommand request, CancellationToken cancellationToken)
    {
        var produto = _produtoRepository.ObterProduto(x => x.Id == request.Id);

        if (produto == null)
        {
            _notify.NewNotification("Erro", "Produto não encontrado");
            return Task.FromResult(cancellationToken);
        }
        
        produto.InformeCaminhoFotoDeCapa(request.CaminhoFotoDeCapa);
        
        _produtoRepository.Update(produto);
        
        if(!_produtoRepository.Commit()) {
            _notify.NewNotification("Erro", "Erro ao inserir dados");
            return Task.FromResult(cancellationToken);
        }
        
        return Task.CompletedTask;
    }
}