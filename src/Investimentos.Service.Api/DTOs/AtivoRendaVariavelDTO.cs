using Investimentos.Service.Api.Enums;

namespace Investimentos.Service.Api.DTOs
{
    public class AtivoRendaVariavelDTO : DTOBase
    {
        //TODO: validação nos DTOs?? Por enquanto herdei a classe Notifiable do Flunt
        public ETipoRendaVariavel TipoRendaVariavel { get; set; }
        public string NomePregao { get; set; }
        public string CodigoNegociacao { get; set; }
        public string CNPJ { get; private set; }
        public string Site { get; private set; }
    }
}
