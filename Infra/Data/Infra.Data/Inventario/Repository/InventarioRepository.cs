using System.Linq.Expressions;
using Domain.Authentication.Inventario.Interface;
using Infra.CrossCutting.Util.Configuration.Core.Repository;
using Infra.Data.Inventario.Context;
using Microsoft.Extensions.Logging;
using ProdutoDomain = Domain.Authentication.Inventario.Entities.Produto;

namespace Infra.Data.Inventario.Repository;

public class InventarioRepository : BaseRepository<InventarioContext, InventarioRepository>, IInventarioRepository
{
    public InventarioRepository(InventarioContext context, ILogger<InventarioRepository> logger) : base(context, logger)
    {
    }

    public ProdutoDomain? ObterProduto(Expression<Func<ProdutoDomain, bool>> predicate)
    {
        return _context.Produtos.FirstOrDefault(predicate);
    }
}