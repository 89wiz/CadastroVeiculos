using System;

namespace CadastroVeiculos.Application.Interfaces.Common
{
    public interface IBaseAppService<TEntity>: IWriteOnlyAppService<TEntity>, IReadOnlyAppService<TEntity>, IDisposable
        where TEntity: class
    {

    }
}