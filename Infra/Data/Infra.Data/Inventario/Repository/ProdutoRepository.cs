using System.Data;
using System.Linq.Expressions;
using Dapper;
using Domain.Inventario.DbViewModels;
using Domain.Inventario.Interface;
using Infra.Core.Base;
using Infra.Data.Inventario.Context;
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
        var query = "select p.\"Id\", p.\"Pro_Nome\", p.\"Pro_Preco\", p.\"Pro_Estoque\", p.\"Ger_CaminhoFotoDeCapa\"" +
                    "from \"Inventario\".\"Produto\" p " +
                    $"offset {skip} limit {take}";
        
        var result = Query<DbProdutoListagemViewModel>(query);

        return result;
    }
    
    public IEnumerable<DbProdutoListagemViewModel> ObterMaisVisualizados()
    {
        var query = "select p.\"Id\", p.\"Pro_Nome\", p.\"Pro_Preco\", p.\"Pro_Estoque\", p.\"Ger_CaminhoFotoDeCapa\"" +
                    "from \"Inventario\".\"Produto\" p " +
                    "order by p.\"Visualizacoes\" desc " +
                    "offset 0 limit 10";
        
        var result = Query<DbProdutoListagemViewModel>(query);

        return result;
    }
    
    public IEnumerable<DbProdutoListagemViewModel> ObterMaisRecentes()
    {
        var query = "select p.\"Id\", p.\"Pro_Nome\", p.\"Pro_Preco\", p.\"Pro_Estoque\", p.\"Ger_CaminhoFotoDeCapa\"" +
                    "from \"Inventario\".\"Produto\" p " +
                    "order by p.\"CriadoEm\" desc " +
                    "offset 0 limit 10";
        
        var result = Query<DbProdutoListagemViewModel>(query);

        return result;
    }

    public IEnumerable<DbProdutoListagemViewModel> ObterMelhoresDescontos()
    {
        var query = "select p.\"Id\", p.\"Pro_Nome\", p.\"Pro_Preco\", p.\"Pro_Estoque\", p.\"Ger_CaminhoFotoDeCapa\"" +
                    "from \"Inventario\".\"Produto\" p " +
                    "order by p.\"Pro_Preco\" desc " +
                    "offset 0 limit 10";
        
        var result = Query<DbProdutoListagemViewModel>(query);

        return result;
    }
    
    private IEnumerable<T> Query<T>(string query) where T : class
    {
        var produtos = _dbConnection.Query<T>(query);
        
        _dbConnection.Close();

        return produtos;
    }
}