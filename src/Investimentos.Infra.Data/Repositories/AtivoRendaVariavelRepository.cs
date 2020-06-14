using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Repositories;
using Investimentos.Infra.Data.Contexts;

namespace Investimentos.Infra.Data.Repositories
{
    public class AtivoRendaVariavelRepository : RepositoryBase<AtivoRendaVariavel>, IAtivoRendaVariavelRepository
    {
        public AtivoRendaVariavelRepository(EFContext ctx) : base(ctx)
        {
        }
    }
}
