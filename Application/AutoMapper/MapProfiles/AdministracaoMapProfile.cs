using Application.Administracao.ViewModels;
using AutoMapper;
using Domain.Administracao.Commands.Pessoa;
using Domain.Administracao.Entities.Pessoa;

namespace Application.AutoMapper.MapProfiles;

public class AdministracaoMapProfile : Profile
{
    public AdministracaoMapProfile()
    {
        //ViewModel to command
        CreateMap<CadastrarPessoaViewModel, CadastrarPessoaCommand>();

        //Command to domain
        CreateMap<CadastrarPessoaCommand, Pessoa>();
    }

}