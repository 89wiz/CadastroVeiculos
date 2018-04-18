using CadastroVeiculos.Domain.Interfaces.Specification;

namespace CadastroVeiculos.Domain.Entities.Specifications.VeiculoSpecs
{
    class VeiculoPlacaIsRequiredSpec : ISpecification<Veiculo>
    {
        public bool IsSatisfiedBy(Veiculo entity)
        {
            return !string.IsNullOrEmpty(entity.Placa);
        }
    }
}
