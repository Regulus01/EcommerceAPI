using Domain.Authentication.Inventario.Interface;
using Infra.CrossCutting.Util.Configuration.Core.Repository;
using Infra.Data.Inventario.Context;

namespace Infra.Data.Produto.Repository;

public class ProdutoRepository : BaseRepository<InventarioContext, ProdutoRepository>, IProdutoRepository
{
    
}