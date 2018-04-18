using CadastroVeiculos.Domain.Entities.Common;
using CadastroVeiculos.Domain.Entities.Validations;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Entities
{
    public class Veiculo : EntitySelfValidated<VeiculoValidation, Veiculo>
    {
        public string Placa { get; set; }
        public string Renavam { get; set; }

        public Guid ProprietarioID { get; set; }
        public Proprietario Proprietario { get; set; }

        public ICollection<VeiculoFoto> Fotos { get; set; }
    }
}