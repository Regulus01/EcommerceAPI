using AutoMapper;
using Domain.Administracao.Commands.Pessoa;
using Domain.Administracao.Interfaces;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Domain.Administracao.Handle;

public class PessoaCommandHandler : IRequestHandler<CadastrarPessoaCommand> 
{
    private readonly IPessoaRepository _repository;
    private readonly IMapper _mapper;
    private readonly Notify _notify;

    public PessoaCommandHandler(IPessoaRepository repository, IMapper mapper, INotify notify)
    {
        _repository = repository;
        _mapper = mapper;
        _notify = notify.Invoke();
    }
    
    public Task Handle(CadastrarPessoaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}