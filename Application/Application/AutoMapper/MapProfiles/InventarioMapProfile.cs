using Application.Inventario.ViewModels;
using AutoMapper;
using Domain.Authentication.Inventario.Commands;
using Domain.Authentication.Inventario.Entities;

namespace Application.AutoMapper.MapProfiles;

public class InventarioMapProfile : Profile
{
    public InventarioMapProfile()
    {
        //ViewModel to command
        CreateMap<ProdutoViewModel, CadastrarProdutoCommand>();
        
        //Command to domain
        CreateMap<CadastrarProdutoCommand, Produto>();
    }
}