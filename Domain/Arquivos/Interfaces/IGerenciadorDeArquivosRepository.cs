using System.Linq.Expressions;
using Domain.Arquivos.Entities;
using Domain.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Arquivos.Interfaces;

public interface IGerenciadorDeArquivosRepository : IBaseRepository
{
     IQueryable<GerenciadorDeArquivos> ObterArquivos(Expression<Func<GerenciadorDeArquivos, bool>> predicate,
         Func<IQueryable<GerenciadorDeArquivos>, IIncludableQueryable<GerenciadorDeArquivos, object>>? includes = null);
}