using System.Linq.Expressions;
using Domain.Authentication.Inventario.Entities;
using Infra.CrossCutting.Util.Configuration.Core.Repository;

namespace Domain.Authentication.Inventario.Interface;

public interface IInventarioRepository : IBaseRepository
{
    Produto? ObterProduto(Expression<Func<Produto, bool>> predicate);
}