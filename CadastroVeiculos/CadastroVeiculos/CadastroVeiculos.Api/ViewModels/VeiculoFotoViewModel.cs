using System;

namespace CadastroVeiculos.Api.ViewModels
{
    public class VeiculoFotoViewModel
    {
        public Guid ID { get; set; }
        public Guid ArquivoID { get; set; }
        public Guid VeiculoID { get; set; }
    }
}