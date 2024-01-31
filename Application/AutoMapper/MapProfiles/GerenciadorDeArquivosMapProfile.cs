using Application.Arquivos.ViewModels;
using AutoMapper;
using Domain.Arquivos.Commands;
using Domain.Arquivos.Entities;

namespace Application.AutoMapper.MapProfiles;

public class GerenciadorDeArquivosMapProfile : Profile
{
    public GerenciadorDeArquivosMapProfile()
    {
        //ViewModel to command
        CreateMap<EnviarGerenciadorDeArquivoViewModel, GerenciadorDeArquivosCommand>();
        
        //Command to domain
        CreateMap<GerenciadorDeArquivosCommand, GerenciadorDeArquivos>();
        
        //Domain to viewModel
        CreateMap<GerenciadorDeArquivos, GetGerenciadorDeArquivosViewModel>();
     
    }
}