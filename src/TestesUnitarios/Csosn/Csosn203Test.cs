using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios.Csosn
{
    public class Csosn203Test
    {
        [Fact]
        public void TestaCsosn203()
        {
            var produto = new Produto
            {
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m,
            };

            var csosn203 = new Csosn203();

            csosn203.Calcula(produto);

            Assert.Equal(18.00m, csosn203.PercentualIcmsSt);
            Assert.Equal(40.00m, csosn203.PercentualMvaSt);
            Assert.Equal(0.00m, csosn203.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn203.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn203.ValorIcmsSt);
        }

        [Fact]
        public void TestaCsosn203ComDescontoCondiconal()
        {
            var produto = new Produto
            {
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                ValorProduto = 1900.00m,
                Desconto = 100m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m,
            };

            var csosn203 = new Csosn203(tipoDesconto:TipoDesconto.Condincional);

            csosn203.Calcula(produto);

            Assert.Equal(18.00m, csosn203.PercentualIcmsSt);
            Assert.Equal(40.00m, csosn203.PercentualMvaSt);
            Assert.Equal(0.00m, csosn203.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn203.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn203.ValorIcmsSt);
        }
    }
}