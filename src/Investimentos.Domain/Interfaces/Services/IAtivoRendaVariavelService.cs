using Investimentos.Domain.Entities;

namespace Investimentos.Domain.Interfaces.Services
{
    public interface IAtivoRendaVariavelService : IServiceBase<AtivoRendaVariavel>
    {
        public void MetodoComMaisDeUmaTransacao();
    }
}
