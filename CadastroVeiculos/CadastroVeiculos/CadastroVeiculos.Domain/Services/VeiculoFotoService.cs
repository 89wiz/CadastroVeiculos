using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Repository;
using CadastroVeiculos.Domain.Interfaces.Service;
using CadastroVeiculos.Domain.Services.Common;

namespace CadastroVeiculos.Domain.Services
{
    public class VeiculoFotoService : Service<VeiculoFoto, IVeiculoFotoRepository>, IVeiculoFotoService
    {
        public VeiculoFotoService(IVeiculoFotoRepository repository) : base(repository) { }
    }
}