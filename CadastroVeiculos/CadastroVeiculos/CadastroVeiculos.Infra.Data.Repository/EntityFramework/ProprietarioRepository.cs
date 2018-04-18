using CadastroVeiculos.Infra.Data.Repository.EntityFramework.Common;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Repository;
using CadastroVeiculos.Infra.Data.Context;

namespace CadastroVeiculos.Infra.Data.Repository.EntityFramework
{
    public class ProprietarioRepository : Repository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(MyContext context) : base(context)
        {
           
        }
    }
}
