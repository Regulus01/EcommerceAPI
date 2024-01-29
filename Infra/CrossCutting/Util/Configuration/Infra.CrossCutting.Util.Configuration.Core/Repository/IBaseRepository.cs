﻿namespace Infra.CrossCutting.Util.Configuration.Core.Repository;

public interface IBaseRepository
{
    bool Commit();
    void Add<T>(T entity) where T : class;
    T? Find<T>(Guid id) where T : class;
    void Delete<T>(T entity) where T : class;
}