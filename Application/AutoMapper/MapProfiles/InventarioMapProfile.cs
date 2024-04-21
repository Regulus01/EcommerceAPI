using Application.Inventario.ViewModels;
using AutoMapper;
using Domain.Inventario.Commands;
using Domain.Inventario.DbViewModels;
using Domain.Inventario.Entities;

namespace Application.AutoMapper.MapProfiles;

public class InventarioMapProfile : Profile
{
    public InventarioMapProfile()
    {
        //ViewModel to command
        CreateMap<CadastroProdutoViewModel, CadastrarProdutoCommand>();
        CreateMap<AtualizarCaminhoFotoDeCapaViewModel, CaminhoFotoCapaCommand>();

        //Command to domain
        CreateMap<CadastrarProdutoCommand, Produto>();
        CreateMap<CaminhoFotoCapaCommand, Produto>();

        //Domain to viewModel
        CreateMap<Produto, ProdutoViewModel>()
            .ForMember(x => x.FotoDeCapa, opt => opt.MapFrom(x => x.CaminhoFotoDeCapa));

        //View model to ViewModel
        CreateMap<DbProdutoListagemViewModel, ProdutoListagemViewModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Pro_Nome))
            .ForMember(x => x.Preco, opt => opt.MapFrom(x => x.Pro_Preco))
            .ForMember(x => x.Estoque, opt => opt.MapFrom(x => x.Pro_Estoque))
            .ForMember(x => x.FotoDeCapa, opt => opt.MapFrom(x => x.Ger_CaminhoFotoDeCapa))
            .ForMember(x => x.Classificacao, opt => opt.MapFrom(x => x.Pro_Classificacao));
    }
}