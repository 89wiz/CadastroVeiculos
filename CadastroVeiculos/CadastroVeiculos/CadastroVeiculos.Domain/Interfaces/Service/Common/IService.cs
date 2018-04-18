using CadastroVeiculos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CadastroVeiculos.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity>
        where TEntity: class
    {
        TEntity Get(Guid id, bool @readonly = false);
        IEnumerable<TEntity> GetAll(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false, params Expression<Func<TEntity, object>>[] includeProperties);
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Delete(TEntity entity);
        ValidationResult Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludeProperties);

    }
}
