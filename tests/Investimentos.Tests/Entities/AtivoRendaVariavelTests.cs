using Investimentos.Domain.Entities;
using Investimentos.Domain.Enums;
using Investimentos.Domain.ValueObjects;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Investimentos.Tests.Entities
{
    [Trait("Category", "Entities")]
    public class AtivoRendaVariavelTests
    {
        [Fact]
        public void AtualizarComCNPJInvalido()
        {
            var ativo = new AtivoRendaVariavel(ETipoRendaVariavel.Ação, "B3", "B3SA3");
            ativo.UpdateCNPJ(new CNPJ("093466010001-25"));

            Debug.WriteLine(string.Join(", ", ativo.Notifications.Select(n => n.Message)));

            Assert.True(ativo.Invalid);
        }

        [Fact]
        public void AtualizarComSiteInvalido()
        {
            var ativo = new AtivoRendaVariavel(ETipoRendaVariavel.Ação, "B3", "B3SA3");
            ativo.UpdateSite(new Site("www.b3.com.br"));

            Debug.WriteLine(string.Join(", ", ativo.Notifications.Select(n => n.Message)));

            Assert.True(ativo.Invalid);
        }

        [Fact]
        public void AtualizarComSiteECNPJValidos()
        {
            var ativo = new AtivoRendaVariavel(ETipoRendaVariavel.Ação, "B3", "B3SA3");
            ativo.UpdateCNPJ(new CNPJ("09346601000125"));
            ativo.UpdateSite(new Site("https://www.b3.com.br"));

            Assert.True(ativo.Valid);
        }
    }
}
