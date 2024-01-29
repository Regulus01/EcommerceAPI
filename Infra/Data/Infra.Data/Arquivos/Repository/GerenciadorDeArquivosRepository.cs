﻿using System.Linq.Expressions;
using Domain.Arquivos.Entities;
using Domain.Arquivos.Interfaces;
using Infra.CrossCutting.Util.Configuration.Core.Repository;
using Infra.Data.Arquivos.Context;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Arquivos.Repository;

public class GerenciadorDeArquivosRepository : BaseRepository<GerenciadorDeArquivosContext, GerenciadorDeArquivosRepository>, 
    IGerenciadorDeArquivosRepository
{
    public GerenciadorDeArquivosRepository(GerenciadorDeArquivosContext context, ILogger<GerenciadorDeArquivosRepository> logger) 
        : base(context, logger)
    {
        
    }

    public GerenciadorDeArquivos? ObterArquivo(Expression<Func<GerenciadorDeArquivos, bool>> predicate, 
        Func<IQueryable<GerenciadorDeArquivos>, IIncludableQueryable<GerenciadorDeArquivos, object>>? includes = null)
    {
        var query = _context.Arquivos.AsQueryable();

        if (includes != null)
            query = includes(query);

        return query.FirstOrDefault(predicate);
    }
    
}