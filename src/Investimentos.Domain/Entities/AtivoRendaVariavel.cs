using Flunt.Validations;
using Investimentos.Domain.Enums;
using Investimentos.Domain.ValueObjects;

namespace Investimentos.Domain.Entities
{
    public class AtivoRendaVariavel : Entity
    {
        public AtivoRendaVariavel(ETipoRendaVariavel tipoRendaVariavel, string nomePregao, string codigoNegociacao)
        {
            TipoRendaVariavel = tipoRendaVariavel;
            NomePregao = nomePregao;
            CodigoNegociacao = codigoNegociacao;

            AddNotifications(new Contract()
                 .Requires()
                 .IsNotNullOrEmpty(nomePregao, "AtivoRendaVariavel.NomePregao", "Nome do pregão é obrigatório")
                 .HasMaxLen(nomePregao, 100, "AtivoRendaVariavel.NomePregao", "Nome do pregão não pode ter mais que 100 caracteres.")
                 .IsNotNullOrEmpty(codigoNegociacao, "AtivoRendaVariavel.CodigoNegociacao", "Código de negociação é obrigatório")
                 .HasMaxLen(codigoNegociacao, 10, "AtivoRendaVariavel.CodigoNegociacao", "Código de negociação não pode ter mais que 10 caracteres.")
             );
        }

        public ETipoRendaVariavel TipoRendaVariavel { get; set; }
        public string NomePregao { get; set; }
        public string CodigoNegociacao { get; set; }
        public CNPJ CNPJ { get; set; }
        public Site Site { get; set; }

        public void UpdateCNPJ(CNPJ cnpj)
        {
            CNPJ = cnpj;
            AddNotifications(cnpj);
        }
        public void UpdateSite(Site site)
        {
            Site = site;
            AddNotifications(Site);
        }
    }
}
