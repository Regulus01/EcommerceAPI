using Application.Administracao.Interface;
using Application.Administracao.ViewModels;
using AutoMapper;
using Domain.Administracao.Commands.Pessoa;
using Domain.Administracao.Interfaces;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Application.Administracao.AppService;

public class PessoaAppService : IPessoaAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IPessoaRepository _repository;

    public PessoaAppService(INotify notify, IMediator mediator, IMapper mapper, IPessoaRepository repository)
    {
        _notify = notify.Invoke();
        _mediator = mediator;
        _mapper = mapper;
        _repository = repository;
    }

    public Guid CadastrarPessoa(CadastrarPessoaViewModel viewModel)
    {
        var command = _mapper.Map<CadastrarPessoaCommand>(viewModel);
        
        var response = _mediator.Send(command);

        return response.Result;
    }
}