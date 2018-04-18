using CadastroVeiculos.Domain.Entities.Common;
using CadastroVeiculos.Domain.Entities.Validations;
using System;

namespace CadastroVeiculos.Domain.Entities
{
    public class VeiculoFoto : EntitySelfValidated<VeiculoFotoValidation, VeiculoFoto>
    {
        public Guid ArquivoID { get; set; }

        public Guid VeiculoID { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}