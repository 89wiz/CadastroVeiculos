using CadastroVeiculos.Domain.Entities.Specifications.VeiculoSpecs;
using CadastroVeiculos.Domain.Validation;

namespace CadastroVeiculos.Domain.Entities.Validations
{
    public class VeiculoValidation : Validation<Veiculo>
    {
        public VeiculoValidation()
        {
            base.AddRule(new ValidationRule<Veiculo>(new VeiculoPlacaIsRequiredSpec(), ValidationMessages.VeiculoPlacaIsRequired));
            base.AddRule(new ValidationRule<Veiculo>(new VeiculoPlacaIsInvalidSpec(), ValidationMessages.VeiculoPlacaIsInvalid));
        }
    }
}