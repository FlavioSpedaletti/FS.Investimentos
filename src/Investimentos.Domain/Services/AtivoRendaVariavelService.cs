using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Repositories;
using Investimentos.Domain.Interfaces.Services;

namespace Investimentos.Domain.Services
{
    public class AtivoRendaVariavelService : ServiceBase<AtivoRendaVariavel>, IAtivoRendaVariavelService
    {
        public AtivoRendaVariavelService(IAtivoRendaVariavelRepository rep)
            : base(rep)
        {

        }
    }
}
