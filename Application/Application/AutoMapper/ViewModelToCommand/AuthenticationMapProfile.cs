using Application.ViewModels;
using AutoMapper;
using Domain.Authentication.Commands;
using Domain.Authentication.Entities;

namespace Application.AutoMapper.ViewModelToCommand;

public class AuthenticationMapProfile : Profile
{
    public AuthenticationMapProfile()
    {
        CreateMap<CadastrarUsuarioCommand, Usuario>();
        CreateMap<CadastroViewModel, CadastrarUsuarioCommand>();
    }
}