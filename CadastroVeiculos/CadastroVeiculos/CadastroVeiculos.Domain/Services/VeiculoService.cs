using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Repository;
using CadastroVeiculos.Domain.Interfaces.Service;
using CadastroVeiculos.Domain.Services.Common;

namespace CadastroVeiculos.Domain.Services
{
    public class VeiculoService : Service<Veiculo, IVeiculoRepository>, IVeiculoService
    {
        public VeiculoService(IVeiculoRepository repository) : base(repository) { }
    }
}