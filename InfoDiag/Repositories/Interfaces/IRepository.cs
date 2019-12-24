using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entity;

namespace Repositories.Interfaces
{
    public interface IRepository<TEntity, in TId> : IDisposable
        where TEntity : class, IBaseEntity<TId>
    {
        IEnumerable<TEntity> All { get; }

        IQueryable<TEntity> AllAsQueryable { get; }

        TEntity Get(TId id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy);

        IQueryable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetAsQueryable<TKey>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TKey>> orderBy);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> where);

        void Delete(IEnumerable<TEntity> query);

        TEntity Save(TEntity entity);

        TEntity Insert(TEntity entity);

        IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Update(IEnumerable<TEntity> entities);
    }
}
