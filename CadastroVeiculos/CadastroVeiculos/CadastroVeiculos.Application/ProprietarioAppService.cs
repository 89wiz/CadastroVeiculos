using CadastroVeiculos.Application.Interfaces;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Service;
using CadastroVeiculos.Infra.Data.Context.Interfaces;

namespace CadastroVeiculos.Application
{
    public class ProprietarioAppService : BaseAppService<Proprietario, IProprietarioService>, IProprietarioAppService
    {
        public ProprietarioAppService(IUnitOfWork uow,
            IProprietarioService service) : base(uow, service)
        {
        }
    }
}