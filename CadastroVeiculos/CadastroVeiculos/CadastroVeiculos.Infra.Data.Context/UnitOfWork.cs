using CadastroVeiculos.Infra.Data.Context.Interfaces;
using System;

namespace CadastroVeiculos.Infra.Data.Context
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly MyContext _dbContext;

        private bool _disposed;

        public UnitOfWork(MyContext context)
        {
            _dbContext = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

    }
}
