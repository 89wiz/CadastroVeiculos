using CadastroVeiculos.Application.Interfaces;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Service;
using CadastroVeiculos.Infra.Data.Context.Interfaces;

namespace CadastroVeiculos.Application
{
    public class VeiculoFotoAppService : BaseAppService<VeiculoFoto, IVeiculoFotoService>, IVeiculoFotoAppService
    {
        public VeiculoFotoAppService(IUnitOfWork uow,
            IVeiculoFotoService service) : base(uow, service)
        {
        }
    }
}