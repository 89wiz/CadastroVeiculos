using CadastroVeiculos.Application.Interfaces.Common;
using CadastroVeiculos.Domain.Interfaces.Service.Common;
using CadastroVeiculos.Domain.Validation;
using CadastroVeiculos.Infra.Data.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CadastroVeiculos.Application
{
    public class BaseAppService : ITransactionAppService
    {
        private IUnitOfWork _uow;

        public BaseAppService(IUnitOfWork uow)
        {
            _uow = uow;
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; private set; }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }

    public class BaseAppService<TEntity, TService> : BaseAppService, IBaseAppService<TEntity>
        where TService : IService<TEntity>
        where TEntity : class
    {
        protected readonly TService _service;

        public BaseAppService(IUnitOfWork uow,
            TService service) : base(uow)
        {
            _service = service;
        }

        public virtual ValidationResult Create(TEntity TEntity)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(TEntity));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _service.Find(predicate);
        }

        public virtual TEntity Get(Guid id)
        {
            return _service.Get(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public virtual ValidationResult Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual ValidationResult Update(TEntity TEntity)
        {
            BeginTransaction();

            ValidationResult.Add(_service.Update(TEntity));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _service.Find(predicate, @readonly, includeProperties);
        }
    }
}
