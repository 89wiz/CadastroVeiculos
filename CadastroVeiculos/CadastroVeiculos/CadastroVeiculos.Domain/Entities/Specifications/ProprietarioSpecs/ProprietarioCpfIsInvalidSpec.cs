using CadastroVeiculos.Domain.Interfaces.Specification;
using CadastroVeiculos.Domain.Services.Helpers;

namespace CadastroVeiculos.Domain.Entities.Specifications.ProprietarioSpecs
{
    class ProprietarioCpfIsInvalidSpec : ISpecification<Proprietario>
    {
        public bool IsSatisfiedBy(Proprietario entity)
        {
            return entity.CPF.IsCnpj();
        }

    }
}
