using Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    /// <summary>
    ///     This class serves has a base for any repository. Any modification to this will have an effect on every class using
    ///     it.
    ///     Be aware
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IBaseEntity<TId>
    {
        #region Fields

        public virtual IEnumerable<TEntity> All => AllAsQueryable.ToArray();

        public virtual IEnumerable<TEntity> AllAsQueryable => GetAsQueryable();

        protected DbContext DataContext;

        protected DbSet<TEntity> DbSet;

        #endregion

        #region Constructors

        protected BaseRepository(DbContext context)
        {
            DataContext = context;
            DbSet = context.Set<TEntity>();
        }

        #endregion

        #region Methods

        public virtual TEntity Get(TId id)
        {
            var entity = DbSet.Find(id);

            return entity;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            return GetAsQueryable(where).ToArray();
        }

        public virtual IEnumerable<TEntity> Get<TKey>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TKey>> orderBy)
        {
            return GetAsQueryable(where, orderBy).ToArray();
        }

        public virtual IEnumerable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> where = null)
        {
            return GetAsQueryable<Guid>(where, null);
        }

        public virtual IEnumerable<TEntity> GetAsQueryable<TKey>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TKey>> orderBy)
        {
            var db = DbSet.AsQueryable();

            if (where != null)
            {
                db = db.Where(where);
            }

            if (orderBy != null)
            {
                return db.OrderBy(orderBy);
            }

            return db;
        }

        public virtual void Delete(TEntity entity)
        {
            OnDelete(entity, true);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            foreach (var obj in DbSet.Where(where))
            {
                OnDelete(obj, false);
            }

            SaveChanges();
        }

        public virtual void Delete(IEnumerable<TEntity> query)
        {
            foreach (var obj in query)
            {
                OnDelete(obj, false);
            }

            SaveChanges();
        }

        public virtual TEntity Save(TEntity entity)
        {
            var obj = Get(entity.Id);

            if (obj == null)
            {
                return Insert(entity);
            }

            return Update(obj, entity);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            DbSet.Add(entity);
            DataContext.Entry(entity).State = EntityState.Added;
            SaveChanges();

            return entity;
        }

        public virtual IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
            SaveChanges();

            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var obj = Get(entity.Id);
            Update(obj, entity);

            return entity;
        }

        public virtual IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
            var entitiesCopy = entities;

            while (entitiesCopy.Count() != 0)
            {
                var entitiesBatch = entitiesCopy.Take(250);
                entitiesCopy = entitiesCopy.Except(entitiesBatch);
                DbSet.UpdateRange(entitiesBatch);
                SaveChanges();
            }

            return entities;
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }

        protected virtual TEntity Update(TEntity existingEntity, TEntity entity)
        {
            DataContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            SaveChanges();

            return entity;
        }

        protected virtual void OnDelete(TEntity entity, bool saveChanges)
        {
            DbSet.Remove(entity);

            if (saveChanges)
            {
                SaveChanges();
            }
        }

        protected void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        #endregion
    }
}
