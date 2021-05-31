using Investimentos.Domain.Interfaces.UOW;
using Investimentos.Infra.Data.Contexts;

namespace Investimentos.Infra.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _ctx;

        public UnitOfWork(EFContext context)
        {
            _ctx = context;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}
