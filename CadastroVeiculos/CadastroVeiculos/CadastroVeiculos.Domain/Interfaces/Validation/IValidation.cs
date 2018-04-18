using CadastroVeiculos.Domain.Validation;

namespace CadastroVeiculos.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}