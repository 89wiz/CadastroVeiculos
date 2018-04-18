using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CadastroVeiculos.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity>
        where TEntity: class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludeProperties);
        void UpdateList(ICollection<TEntity> entities, Expression<Func<TEntity, bool>> predicate);
        void DeleteNotExistent(ICollection<TEntity> entities, Expression<Func<TEntity, bool>> predicate);
        void DeleteAndAddList(ICollection<TEntity> entities, Expression<Func<TEntity, bool>> predicate);
        void AddOrUpdate(TEntity entity);
        void AddOrUpdateList(ICollection<TEntity> entities);
        void SetAsAdded(TEntity entity);
        void SetExistingAsUnchanged(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
