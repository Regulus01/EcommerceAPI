using Application.Administracao.Interface;
using AutoMapper;
using Domain.Administracao.Interfaces;
using Infra.CrossCutting.Util.Notifications.Implementation;
using MediatR;

namespace Application.Administracao.AppService;

public class PessoaAppService : IPessoaAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IPessoaRepository _repository;

    public PessoaAppService(Notify notify, IMediator mediator, IMapper mapper, IPessoaRepository repository)
    {
        _notify = notify;
        _mediator = mediator;
        _mapper = mapper;
        _repository = repository;
    }
}