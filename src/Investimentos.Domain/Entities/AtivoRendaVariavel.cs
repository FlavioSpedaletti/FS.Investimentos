using Flunt.Validations;
using Investimentos.Domain.Enums;
using System.Text.RegularExpressions;

namespace Investimentos.Domain.Entities
{
    public class AtivoRendaVariavel : EntityBase
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
        public string CNPJ { get; private set; }
        public string Site { get; private set; }

        public void UpdateCNPJ(string cnpj)
        {
            CNPJ = cnpj;

            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(cnpj, 14, "AtivoRendaVariavel.CNPJ", "CNPJ não pode ter mais que 14 caracteres.")
                .IsTrue(new Regex("^[0-9]+$").IsMatch(cnpj), "AtivoRendaVariavel.CNPJ", "CNPJ deve conter apenas números.")
                .IsTrue(ValidarDigitoVerificador(cnpj), "AtivoRendaVariavel.CNPJ", "Dígito verificador do CNPJ inválido.")
            );
        }

        public void UpdateSite(string site)
        {
            Site = site;

            AddNotifications(new Contract()
               .Requires()
               .HasMaxLen(site, 50, "AtivoRendaVariavel.Site", "Site não pode ter mais que 50 caracteres.")
               .IsUrlOrEmpty(site, "AtivoRendaVariavel.Site", "Site inválido.")
           );
        }

        private bool ValidarDigitoVerificador(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
