using CadastroVeiculos.Application.Interfaces;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Service;
using CadastroVeiculos.Infra.Data.Context.Interfaces;

namespace CadastroVeiculos.Application
{
    public class VeiculoAppService : BaseAppService<Veiculo, IVeiculoService>, IVeiculoAppService
    {
        IVeiculoFotoAppService _fotoService;

        public VeiculoAppService(IUnitOfWork uow,
            IVeiculoService service, IVeiculoFotoAppService fotoService) : base(uow, service)
        {
            _fotoService = fotoService;
        }
    }
}