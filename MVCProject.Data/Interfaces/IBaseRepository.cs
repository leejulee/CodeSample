using System.Collections.Generic;

namespace Enterprise
{
    public interface IBaseRepository
    {
        int Add<T>(T model) where T : class;

        int Delete<T, TId>(TId id) where T : class;

        TEntity GetData<TEntity, TId>(TId id, bool isRowMapper = false) where TEntity : class, new();

        IList<TEntity> GetAllData<TEntity>(bool isRowMapper = false) where TEntity : class, new();

        int Update<TEntity>(TEntity model) where TEntity : class;
    }
}