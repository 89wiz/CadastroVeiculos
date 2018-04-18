using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Repository;
using CadastroVeiculos.Domain.Interfaces.Service;
using CadastroVeiculos.Domain.Services.Common;

namespace CadastroVeiculos.Domain.Services
{
    public class ProprietarioService : Service<Proprietario, IProprietarioRepository>, IProprietarioService
    {
        public ProprietarioService(IProprietarioRepository repository) : base(repository) { }
    }
}