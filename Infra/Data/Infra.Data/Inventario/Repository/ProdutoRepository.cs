using System.Data;
using System.Linq.Expressions;
using Dapper;
using Domain.Inventario.Interface;
using Infra.Core.Base;
using Infra.Data.Inventario.Context;
using Infra.Data.Inventario.DbViewModels;
using Microsoft.Extensions.Logging;
using ProdutoDomain = Domain.Inventario.Entities.Produto;

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

    public IEnumerable<DbProdutoListagemViewModel> Listagem(int skip, int take)
    {
        var query = "select p.\"Pro_Id\", p.\"Pro_Nome\", p.\"Pro_Preco\", p.\"Pro_Estoque\", p.\"Ger_CaminhoFotoDeCapa\"" +
                    "from \"Inventario\".\"Produto\" p " +
                    $"offset {skip} limit {take}";
        
        var produtos = _dbConnection.Query<DbProdutoListagemViewModel>(query);
        
        _dbConnection.Close();

        return produtos;
    }
    
    public List<ProdutoDomain> ObterProdutos(Expression<Func<ProdutoDomain, bool>> predicate, 
                                    Expression<Func<ProdutoDomain, bool>> orderBy)
    {
        var query = _context.Produtos.Where(predicate)
                                     .OrderBy(predicate);

        return query.ToList();
    }
}