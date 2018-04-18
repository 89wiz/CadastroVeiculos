using CadastroVeiculos.Domain.Entities.Common;
using CadastroVeiculos.Domain.Interfaces.Repository.Common;
using CadastroVeiculos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CadastroVeiculos.Infra.Data.Repository.EntityFramework.Common
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : Entity
    {
        internal readonly DbContext _dbContext;
        internal readonly DbSet<TEntity> _dbSet;

        protected DbContext Context
        {
            get { return _dbContext; }
        }
        protected DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public Repository(MyContext context){
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
             DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludeProperties)
        {
            var entry = _dbContext.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;

            foreach (var property in excludeProperties)
            {
                entry.Property(property).IsModified = false;
            }
        }

        public virtual void UpdateList(ICollection<TEntity> entities, Expression<Func<TEntity, bool>> predicate)
        {
            DeleteNotExistent(entities, predicate);
            AddOrUpdateList(entities);
        }

        public virtual void DeleteNotExistent(ICollection<TEntity> entities, Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var e in Find(predicate, true))
            {
                if (!entities.Any(x => x.ID.Equals(e.ID))) Delete(e);
            }
        }

        public virtual void DeleteAndAddList(ICollection<TEntity> entities, Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var e in Find(predicate, true))
            {
                Delete(e);
            }

            foreach (var e in entities)
            {
                Add(e);
            }
        }

        public virtual void AddOrUpdate(TEntity entity)
        {
            if (entity.ID.Equals(Guid.Empty)) Add(entity);
            else Update(entity);
        }

        public virtual void AddOrUpdateList(ICollection<TEntity> entities)
        {
            foreach (var e in entities)
            {
                AddOrUpdate(e);
            }
        }

        public virtual void SetAsAdded(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Added;
        }

        public virtual void SetExistingAsUnchanged(TEntity entity)
        {
            if(!entity.ID.Equals(Guid.Empty))
            {
                var entry = _dbContext.Entry(entity);
                entry.State = EntityState.Unchanged;
            }
        }

        public virtual TEntity Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll(bool @readonly = false)
        {
            return @readonly
              ? DbSet.AsNoTracking().ToList()
              : DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly
               ? DbSet.Where(predicate).AsNoTracking()
               : DbSet.Where(predicate);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {

            var queryableResultWithIncludes = includeProperties.Aggregate(DbSet.AsQueryable(), (current, include)
                 => current.Include(include));

            return @readonly
                ? queryableResultWithIncludes.Where(predicate).AsNoTracking()
                : queryableResultWithIncludes.Where(predicate);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}