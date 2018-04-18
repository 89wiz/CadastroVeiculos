using CadastroVeiculos.Domain.Interfaces.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CadastroVeiculos.Domain.Validation;
using CadastroVeiculos.Domain.Interfaces.Repository.Common;
using CadastroVeiculos.Domain.Interfaces.Validation;
using CadastroVeiculos.Domain.Entities.Common;

namespace CadastroVeiculos.Domain.Services.Common
{
    public class Service<TEntity, TRepository> : IService<TEntity>
        where TEntity : Entity
        where TRepository : IRepository<TEntity>
    {

        #region Constructor

        private readonly TRepository _repository;
        private readonly ValidationResult _validationResult;

        public Service(TRepository repository)
        {
            _repository = repository;
            _validationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected TRepository Repository
        {
            get { return _repository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.Find(predicate, @readonly);
        }

        public virtual TEntity Get(Guid id, bool @readonly = false)
        {
            return @readonly
             ? _repository.Get(id) //TODO: Repository Ready Only
            : _repository.Get(id);
        }

        public virtual IEnumerable<TEntity> GetAll(bool @readonly = false)
        {
            return _repository.GetAll(@readonly);
        }

        public virtual ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            entity.GenerateGuid();
            Repository.Add(entity);
            return ValidationResult;
        }

        public virtual ValidationResult Delete(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repository.Delete(entity);
            return _validationResult;
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            if (entity is ISelfValidation selfValidationEntity && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            entity.UpdateGuid();
            _repository.Update(entity);
            return _validationResult;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.Find(predicate, @readonly, includeProperties);
        }

        public virtual ValidationResult Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludeProperties)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            if (entity is ISelfValidation selfValidationEntity && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            entity.UpdateGuid();
            _repository.Update(entity, excludeProperties);
            return _validationResult;
        }
    }
}
