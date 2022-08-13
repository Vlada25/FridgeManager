using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace FridgeManager.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAllEntities(bool trackChanges);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void CreateEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        object ExecuteScalar(string sqlQuery, SqlParameter param);
    }
}
