using Flunt.Validations;
using System.Text.RegularExpressions;

namespace Investimentos.Domain.ValueObjects
{
    public class CNPJ : ValeuObject
    {
        public CNPJ(string numeroCNPJ)
        {
            NumeroCNPJ = numeroCNPJ;

            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(numeroCNPJ, 14, "AtivoRendaVariavel.CNPJ", "CNPJ não pode ter mais que 14 caracteres.")
                .IsTrue(new Regex("^[0-9]+$").IsMatch(NumeroCNPJ), "AtivoRendaVariavel.CNPJ", "CNPJ deve conter apenas números.")
                .IsTrue(ValidarDigitoVerificador(), "AtivoRendaVariavel.CNPJ", "Dígito verificador do CNPJ inválido.")
            );
        }

        public string NumeroCNPJ { get; private set; }
        
        private bool ValidarDigitoVerificador()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var cnpj = NumeroCNPJ.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

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
