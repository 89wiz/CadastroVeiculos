using CadastroVeiculos.Domain.Entities.Common;
using CadastroVeiculos.Domain.Entities.Validations;

namespace CadastroVeiculos.Domain.Entities
{
    public class Proprietario : EntitySelfValidated<ProprietarioValidation, Proprietario>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}