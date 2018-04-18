using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CadastroVeiculos.Application.Interfaces.Common
{
    public interface IReadOnlyAppService<TEntity>
      where TEntity : class
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly=false, params Expression<Func<TEntity, object>>[] includeProperties);

    }
}