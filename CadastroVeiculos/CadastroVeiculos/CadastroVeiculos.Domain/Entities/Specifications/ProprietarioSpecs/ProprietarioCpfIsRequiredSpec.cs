using CadastroVeiculos.Domain.Interfaces.Specification;

namespace CadastroVeiculos.Domain.Entities.Specifications.ProprietarioSpecs
{
    class ProprietarioCpfIsRequiredSpec : ISpecification<Proprietario>
    {
        public bool IsSatisfiedBy(Proprietario entity)
        {
            return !string.IsNullOrEmpty(entity.CPF);
        }
    }
}
