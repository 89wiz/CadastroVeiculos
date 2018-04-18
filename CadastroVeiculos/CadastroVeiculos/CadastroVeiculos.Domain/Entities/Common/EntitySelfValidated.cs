using CadastroVeiculos.Domain.Interfaces.Validation;
using CadastroVeiculos.Domain.Validation;
using System;

namespace CadastroVeiculos.Domain.Entities.Common
{
    public class EntitySelfValidated<TValidation, TEntity> : Entity, ISelfValidation
        where TValidation : Validation<TEntity>, new()
        where TEntity : Entity
    {
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid
        {
            get
            {
                var selfValidation = new TValidation();
                ValidationResult = selfValidation.Valid(this as TEntity);
                return ValidationResult.IsValid;
            }
        }
    }
}