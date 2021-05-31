using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Repositories;
using Investimentos.Domain.Interfaces.Services;
using Investimentos.Domain.Interfaces.UOW;

namespace Investimentos.Domain.Services
{
    public class AtivoRendaVariavelService : ServiceBase<AtivoRendaVariavel>, IAtivoRendaVariavelService
    {
        private readonly IAtivoRendaVariavelRepository _rep;
        private readonly IUnitOfWork _uow;

        public AtivoRendaVariavelService(IAtivoRendaVariavelRepository rep, IUnitOfWork uow)
            : base(rep, uow)
        {
            _rep = rep;
            _uow = uow;
        }

        public void MetodoComMaisDeUmaTransacao()
        {
            var ativo = new AtivoRendaVariavel(Enums.ETipoRendaVariavel.FII, "teste", "test11");
            _rep.Insert(ativo);

            _rep.Delete(11);
            _rep.Delete(12);
            _uow.Commit();
        }
    }
}
