using FridgeManager.Domain;
using FridgeManager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
