using FridgeManager.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FridgeManager.Database.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected FridgeManagerDbContext dbContext;

        public BaseRepository(FridgeManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateEntity(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void DeleteEntity(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public object ExecuteScalar(string sqlQuery, SqlParameter param)
        {
            dbContext.Database.ExecuteSqlRaw(sqlQuery, param);
            return param.Value;
        }

        public IQueryable<T> GetAllEntities(bool trackChanges)
        {
            return !trackChanges ? dbContext.Set<T>().AsNoTracking() : dbContext.Set<T>();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                dbContext.Set<T>().Where(expression).AsNoTracking() :
                dbContext.Set<T>().Where(expression);
        }

        public void UpdateEntity(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }


    }
}
