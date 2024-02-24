using System.Linq.Expressions;
using Domain.Base;
using Domain.Inventario.Entities;
using Infra.Data.Inventario.DbViewModels;

namespace Domain.Inventario.Interface;

public interface IProdutoRepository : IBaseRepository
{
    /// <summary>
    /// Método para obter um produto especifico a partir de um predicate
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <returns>Produto</returns>
    Produto? ObterProduto(Expression<Func<Produto, bool>> predicate);
    
    /// <summary>
    /// Método para obter uma listagem de produtos
    /// </summary>
    /// <param name="skip">Inicio da listagem</param>
    /// <param name="take">Quantidade de elementos</param>
    /// <returns>Lista com produtos</returns>
    IEnumerable<DbProdutoListagemViewModel> Listagem(int skip, int take);

}