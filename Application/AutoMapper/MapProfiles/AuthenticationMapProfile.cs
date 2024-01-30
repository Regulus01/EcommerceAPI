using Application.Authorization.ViewModels;
using Application.ViewModels;
using AutoMapper;
using Domain.Authentication.Commands;
using Domain.Authentication.Configuration;
using Domain.Authentication.Entities;

namespace Application.AutoMapper.MapProfiles;

public class AuthenticationMapProfile : Profile
{
    public AuthenticationMapProfile()
    {
        //ViewModel to command
        CreateMap<CadastroViewModel, CadastrarUsuarioCommand>();
        CreateMap<LoginViewModel, LoginCommand>();
        
        //Command to domain
        CreateMap<CadastrarUsuarioCommand, Usuario>();
        
        //Domain to viewModel
        CreateMap<TokenModel, TokenViewModel>();
    }
}