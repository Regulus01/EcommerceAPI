using System.Data;
using System.Linq.Expressions;
using Application.Inventario.ViewModels;
using Dapper;
using Domain.Authentication.Inventario.Interface;
using Infra.CrossCutting.Util.Configuration.Core.Repository;
using Infra.Data.Inventario.Context;
using Microsoft.Extensions.Logging;
using ProdutoDomain = Domain.Authentication.Inventario.Entities.Produto;

namespace Infra.Data.Inventario.Repository;

public class ProdutoRepository : BaseRepository<InventarioContext, ProdutoRepository>, IProdutoRepository
{
    private readonly IDbConnection _dbConnection;
    
    public ProdutoRepository(InventarioContext context, ILogger<ProdutoRepository> logger, 
        IDbConnection dbConnection) : base(context, logger)
    {
        _dbConnection = dbConnection;
    }

    public ProdutoDomain? ObterProduto(Expression<Func<ProdutoDomain, bool>> predicate)
    {
        return _context.Produtos.FirstOrDefault(predicate);
    }

    public IEnumerable<ProdutoListagemViewModel> Listagem(int skip, int take)
    {
        var query = "select p.\"Pro_Id\", p.\"Pro_Nome\", p.\"Pro_Preco\"" +
                    "from \"Inventario\".\"Produto\" p " +
                    $"offset {skip} limit {take}";
        
        var produtos = _dbConnection.Query<ProdutoListagemViewModel>(query);
        
        _dbConnection.Close();

        return produtos;
    }
}