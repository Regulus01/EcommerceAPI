using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infra.CrossCutting.Util.Configuration.Core.Repository;

public class BaseRepository<TContext, TL> where TContext : DbContext
{
    protected ILogger<TL> _logger;
    protected TContext _context;

    public BaseRepository(TContext context, ILogger<TL> logger)
    {
        _logger = logger;
        _context = context;
    }
    
    public bool Commit()
    {
        try
        {
            var result = _context.SaveChanges();
            return result >= 1;
        }
        catch (Exception e)
        {
            _logger.LogInformation("Erro ao commitar entidades no banco de dados: {error}", e.Message);
            return false;
        }
    }
    
    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }
    
    public T? Find<T>(Guid id) where T : class
    {
        return _context.Find<T>(id);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }
}