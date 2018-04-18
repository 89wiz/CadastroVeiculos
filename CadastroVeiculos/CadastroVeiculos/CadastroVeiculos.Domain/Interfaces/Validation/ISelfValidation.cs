using CadastroVeiculos.Domain.Validation;

namespace CadastroVeiculos.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}