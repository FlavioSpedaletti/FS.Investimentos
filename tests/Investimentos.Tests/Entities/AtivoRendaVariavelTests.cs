using Investimentos.Domain.Entities;
using Investimentos.Domain.Enums;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Investimentos.Tests.Entities
{
    [Trait("Category", "Entities")]
    public class AtivoRendaVariavelTests
    {
        [Theory]
        [InlineData("09.346.601/0001-25")]
        [InlineData("093466010001-5")]
        [InlineData("093466010001-25")]
        [InlineData("09.346.601/0001-24")]
        public void AtualizarComCNPJInvalido(string cnpj)
        {
            var ativo = new AtivoRendaVariavel(ETipoRendaVariavel.Ação, "B3", "B3SA3");
            ativo.UpdateCNPJ(cnpj);

            Debug.WriteLine(string.Join(", ", ativo.Notifications.Select(n => n.Message)));

            Assert.True(ativo.Invalid);
        }

        [Fact]
        public void AtualizarComSiteInvalido()
        {
            var ativo = new AtivoRendaVariavel(ETipoRendaVariavel.Ação, "B3", "B3SA3");
            ativo.UpdateSite("www.b3.com.br");

            Debug.WriteLine(string.Join(", ", ativo.Notifications.Select(n => n.Message)));

            Assert.True(ativo.Invalid);
        }

        [Theory]
        [InlineData("09346601000125")]
        [InlineData("17523961000183")]
        [InlineData("80406772000167")]
        [InlineData("58828173000182")]
        [InlineData("10348281000121")]
        public void AtualizarComSiteECNPJValidos(string cnpj)
        {
            var ativo = new AtivoRendaVariavel(ETipoRendaVariavel.Ação, "B3", "B3SA3");
            
            ativo.UpdateCNPJ(cnpj);
            ativo.UpdateSite("https://www.b3.com.br");

            Assert.True(ativo.Valid);
        }
    }
}
