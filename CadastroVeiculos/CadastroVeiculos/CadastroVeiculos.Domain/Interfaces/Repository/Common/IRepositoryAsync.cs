using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadastroVeiculos.Domain.Interfaces.Repository.Common
{
    public interface IRepositoryAsync<TEntity>
        where TEntity: class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll(bool @readonly = false);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}
