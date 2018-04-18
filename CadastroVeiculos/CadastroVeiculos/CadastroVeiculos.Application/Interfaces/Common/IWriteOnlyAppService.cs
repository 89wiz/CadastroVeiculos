﻿using CadastroVeiculos.Domain.Validation;

namespace CadastroVeiculos.Application.Interfaces.Common
{
    public interface IWriteOnlyAppService<in TEntity>
        where TEntity: class
    {
        ValidationResult Create(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Remove(TEntity entity);
    }
}