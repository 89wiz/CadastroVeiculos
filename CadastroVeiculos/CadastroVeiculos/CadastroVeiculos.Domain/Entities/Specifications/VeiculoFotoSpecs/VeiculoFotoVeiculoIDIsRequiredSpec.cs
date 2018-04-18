using CadastroVeiculos.Domain.Interfaces.Specification;
using System;

namespace CadastroVeiculos.Domain.Entities.Specifications.VeiculoFotoSpecs
{
    class VeiculoFotoVeiculoIDIsRequiredSpec : ISpecification<VeiculoFoto>
    {
        public bool IsSatisfiedBy(VeiculoFoto entity)
        {
            return !entity.VeiculoID.Equals(Guid.Empty);
        }
    }
}
