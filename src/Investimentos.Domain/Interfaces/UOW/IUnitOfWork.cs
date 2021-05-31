namespace Investimentos.Domain.Interfaces.UOW
{
    public interface IUnitOfWork
    {
        int Commit();
        void Rollback();
    }
}
