using Application.Inventario.ViewModels;
using AutoMapper;
using Domain.Authentication.Inventario.Entities;
using Domain.Inventario.Commands;
using Infra.Data.Inventario.DbViewModels;

namespace Application.AutoMapper.MapProfiles;

public class InventarioMapProfile : Profile
{
    public InventarioMapProfile()
    {
        //ViewModel to command
        CreateMap<CadastroProdutoViewModel, CadastrarProdutoCommand>();

        //Command to domain
        CreateMap<CadastrarProdutoCommand, Produto>();

        //Domain to viewModel
        CreateMap<Produto, ProdutoViewModel>();

        //View model to ViewModel
        CreateMap<DbProdutoListagemViewModel, ProdutoListagemViewModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Pro_Id))
            .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Pro_Nome))
            .ForMember(x => x.Preco, opt => opt.MapFrom(x => x.Pro_Preco))
            .ForMember(x => x.Estoque, opt => opt.MapFrom(x => x.Pro_Estoque));
    }
}