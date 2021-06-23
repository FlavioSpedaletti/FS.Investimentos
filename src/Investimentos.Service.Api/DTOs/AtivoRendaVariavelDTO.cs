using Flunt.Validations;
using Investimentos.Service.Api.Enums;

namespace Investimentos.Service.Api.DTOs
{
    public class AtivoRendaVariavelDTO : DTOBase
    {
        public AtivoRendaVariavelDTO(ETipoRendaVariavel tipoRendaVariavel, string nomePregao, string codigoNegociacao)
        {
            TipoRendaVariavel = tipoRendaVariavel;
            NomePregao = nomePregao;
            CodigoNegociacao = codigoNegociacao;

            AddNotifications(new Contract()
                 .Requires()
                 .IsNotNullOrEmpty(nomePregao, "AtivoRendaVariavelDTO.NomePregao", "Nome do pregão é obrigatório")
                 .HasMaxLen(nomePregao, 100, "AtivoRendaVariavelDTO.NomePregao", "Nome do pregão não pode ter mais que 100 caracteres.")
                 .IsNotNullOrEmpty(codigoNegociacao, "AtivoRendaVariavelDTO.CodigoNegociacao", "Código de negociação é obrigatório")
                 .HasMaxLen(codigoNegociacao, 10, "AtivoRendaVariavelDTO.CodigoNegociacao", "Código de negociação não pode ter mais que 10 caracteres.")
             );
        }
        //TODO: validação nos DTOs?? Por enquanto herdei a classe Notifiable do Flunt
        public ETipoRendaVariavel TipoRendaVariavel { get; set; }
        public string NomePregao { get; set; }
        public string CodigoNegociacao { get; set; }
        public string CNPJ { get; private set; }
        public string Site { get; private set; }
    }
}
