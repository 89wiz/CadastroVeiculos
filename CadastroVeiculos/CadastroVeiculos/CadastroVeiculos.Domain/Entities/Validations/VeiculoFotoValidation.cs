using CadastroVeiculos.Domain.Entities.Specifications.VeiculoFotoSpecs;
using CadastroVeiculos.Domain.Validation;

namespace CadastroVeiculos.Domain.Entities.Validations
{
    public class VeiculoFotoValidation : Validation<VeiculoFoto>
    {
        public VeiculoFotoValidation()
        {
            base.AddRule(new ValidationRule<VeiculoFoto>(new VeiculoFotoArquivoIsRequiredSpec(), ValidationMessages.VeiculoFotoArquivoIsRequired));
            base.AddRule(new ValidationRule<VeiculoFoto>(new VeiculoFotoVeiculoIDIsRequiredSpec(), ValidationMessages.VeiculoFotoVeiculoIDIsRequired));
        }
    }
}