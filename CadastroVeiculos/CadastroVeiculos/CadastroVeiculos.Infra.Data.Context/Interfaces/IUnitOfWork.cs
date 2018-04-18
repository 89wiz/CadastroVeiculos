namespace CadastroVeiculos.Infra.Data.Context.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
