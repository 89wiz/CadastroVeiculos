using CadastroVeiculos.Domain.Entities.Specifications.ProprietarioSpecs;
using CadastroVeiculos.Domain.Validation;

namespace CadastroVeiculos.Domain.Entities.Validations
{
    public class ProprietarioValidation : Validation<Proprietario>
    {
        public ProprietarioValidation()
        {
            base.AddRule(new ValidationRule<Proprietario>(new ProprietarioNomeIsRequiredSpec(), ValidationMessages.ProprietarioNomeIsRequired));
            base.AddRule(new ValidationRule<Proprietario>(new ProprietarioCpfIsRequiredSpec(), ValidationMessages.ProprietarioCpfIsRequired));
            base.AddRule(new ValidationRule<Proprietario>(new ProprietarioCpfIsInvalidSpec(), ValidationMessages.ProprietarioCpfIsInvalid));
        }
    }
}