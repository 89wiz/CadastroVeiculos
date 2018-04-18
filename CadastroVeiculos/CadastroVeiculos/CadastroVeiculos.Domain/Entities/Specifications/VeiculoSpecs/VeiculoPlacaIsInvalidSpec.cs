using CadastroVeiculos.Domain.Interfaces.Specification;
using System.Text.RegularExpressions;

namespace CadastroVeiculos.Domain.Entities.Specifications.VeiculoSpecs
{
    class VeiculoPlacaIsInvalidSpec : ISpecification<Veiculo>
    {
        public bool IsSatisfiedBy(Veiculo entity)
        {
            return Regex.Match(entity.Placa, "[A-Z]{3}[0-9]{4}").Success;
        }
    }
}
