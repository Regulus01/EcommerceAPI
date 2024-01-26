namespace Infra.CrossCutting.Util.Configuration.Core.Repository;

public interface IBaseRepository
{
    bool Commit();
    void Add<T>(T entity) where T : class;
}