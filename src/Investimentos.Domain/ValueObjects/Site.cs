using Flunt.Validations;
using Investimentos.Domain.Entities;

namespace Investimentos.Domain.ValueObjects
{
    public class Site : Entity
    {
        public Site(string enderecoSite)
        {

            EnderecoSite = enderecoSite;

            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(enderecoSite, 50, "AtivoRendaVariavel.Site", "Site não pode ter mais que 50 caracteres.")
                .IsUrlOrEmpty(enderecoSite, "AtivoRendaVariavel.Site", "Site inválido.")
            );
        }

        public string EnderecoSite { get; private set; }
    }
}
