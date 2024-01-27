using AutoMapper;
using Domain.Authentication.Inventario.Commands;
using Domain.Authentication.Inventario.Entities;
using Domain.Authentication.Inventario.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Domain.Authentication.Inventario.Handle;

public class ProdutoCommandHandler : IRequestHandler<CadastrarProdutoCommand> 
{
    private readonly IInventarioRepository _inventarioRepository;
    private readonly IMapper _mapper;
    private readonly Notify _notify;

    public ProdutoCommandHandler(IInventarioRepository inventarioRepository, IMapper mapper, INotify notify)
    {
        _inventarioRepository = inventarioRepository;
        _mapper = mapper;
        _notify = notify.Invoke();
    }
    
    public Task Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = _mapper.Map<Produto>(request);
        
        _inventarioRepository.Add(produto);
        
        if (!_inventarioRepository.Commit())
        {
            _notify.NewNotification("Erro", "Erro ao inserir dados");
            return Task.FromResult(cancellationToken);
        }

        return Task.CompletedTask;
    }
}