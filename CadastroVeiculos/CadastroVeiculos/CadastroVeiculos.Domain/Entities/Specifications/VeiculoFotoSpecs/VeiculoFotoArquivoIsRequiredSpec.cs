using CadastroVeiculos.Domain.Interfaces.Specification;
using System;

namespace CadastroVeiculos.Domain.Entities.Specifications.VeiculoFotoSpecs
{
    class VeiculoFotoArquivoIsRequiredSpec : ISpecification<VeiculoFoto>
    {
        public bool IsSatisfiedBy(VeiculoFoto entity)
        {
            return !entity.ArquivoID.Equals(Guid.Empty);
        }
    }
}
