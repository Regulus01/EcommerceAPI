using AutoMapper;
using Domain.Administracao.Commands.Pessoa;
using Domain.Administracao.Entities.Pessoa;
using Domain.Administracao.Interfaces;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Domain.Administracao.Handle;

public class PessoaCommandHandler : IRequestHandler<CadastrarPessoaCommand, Guid> 
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
    
    public Task<Guid> Handle(CadastrarPessoaCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Nome))
        {
           _notify.NewNotification("Erro", "É necessário informar o nome");
           return Task.FromResult(Guid.Empty);
        }
        
        if (string.IsNullOrEmpty(request.Cpf))
        {
            _notify.NewNotification("Erro", "É necessário informar o cpf");
            return Task.FromResult(Guid.Empty);
        }
        
        if (string.IsNullOrEmpty(request.Telefone))
        {
            _notify.NewNotification("Erro", "É necessário informar o telefone");
            return Task.FromResult(Guid.Empty);
        }

        var pessoa = _mapper.Map<Pessoa>(request);
        
        _repository.Add(pessoa);

        return Task.FromResult(_repository.Commit() ? pessoa.Id : Guid.Empty);
    }
}