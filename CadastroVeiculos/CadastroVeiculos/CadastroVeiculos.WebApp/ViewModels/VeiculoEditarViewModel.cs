using System;

namespace CadastroVeiculos.WebApp.ViewModels
{
    public class VeiculoEditarViewModel
    {
        public Guid ID { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public ProprietarioEditarViewModel Proprietario { get; set; }
    }
}