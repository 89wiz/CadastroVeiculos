namespace CadastroVeiculos.Application.Interfaces.Common
{
    public interface ITransactionAppService
    {
        void BeginTransaction();
        void Commit();
    }
}