using Investimentos.Domain.ValueObjects;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Investimentos.Tests.ValueObjects
{
    [Trait("Category", "ValueObjects")]
    public class CNPJTests
    {
        [Theory]
        [InlineData("09.346.601/0001-25")]
        [InlineData("093466010001-5")]
        public void ComPontoBarraHifen(string numeroCNPJ)
        {
            var cnpj = new CNPJ(numeroCNPJ);

            Debug.WriteLine(string.Join(", ", cnpj.Notifications.Select(n => n.Message)));

            Assert.True(cnpj.Invalid);
        }

        [Fact]
        public void DigitoVerificadorInvalido()
        {
            var cnpj = new CNPJ("09.346.601/0001-24");

            Debug.WriteLine(string.Join(", ", cnpj.Notifications.Select(n => n.Message)));

            Assert.True(cnpj.Invalid);
        }

        [Theory]
        [InlineData("09346601000125")]
        [InlineData("17523961000183")]
        [InlineData("80406772000167")]
        [InlineData("58828173000182")]
        [InlineData("10348281000121")]
        public void Ok(string numeroCNPJ)
        {
            var cnpj = new CNPJ(numeroCNPJ);

            Assert.True(cnpj.Valid);
        }
    }
}
