using CadastroVeiculos.Infra.Data.Repository.EntityFramework.Common;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces.Repository;
using CadastroVeiculos.Infra.Data.Context;

namespace CadastroVeiculos.Infra.Data.Repository.EntityFramework
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(MyContext context) : base(context)
        {
           
        }
    }
}
