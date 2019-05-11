using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Scheduler.DataAccess.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(IQueryable<int> id);
        TEntity FindAsNoTracking(int id);
        TEntity Find(int id);
        TEntity Find(Func<TEntity, Boolean> predicate);
        void Create(TEntity entity);

        void Delete(int id);

        void Update(TEntity entity);
        bool Any(Func<TEntity, Boolean> predicate);
    }
}
