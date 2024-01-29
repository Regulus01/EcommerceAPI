﻿using System.Linq.Expressions;
using Domain.Arquivos.Entities;
using Infra.CrossCutting.Util.Configuration.Core.Repository;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Arquivos.Interfaces;

public interface IGerenciadorDeArquivosRepository : IBaseRepository
{
     GerenciadorDeArquivos? ObterArquivo(Expression<Func<GerenciadorDeArquivos, bool>> predicate,
        Func<IQueryable<GerenciadorDeArquivos>, IIncludableQueryable<GerenciadorDeArquivos, object>>? includes = null);
}