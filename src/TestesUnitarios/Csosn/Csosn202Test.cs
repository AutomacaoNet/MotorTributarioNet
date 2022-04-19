using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios.Csosn
{
    public class Csosn202Test
    {
        [Fact]
        public void TestaCsosn202()
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

            var csosn202 = new Csosn202();

            csosn202.Calcula(produto);

            Assert.Equal(18.00m, csosn202.PercentualIcmsSt);
            Assert.Equal(40.00m, csosn202.PercentualMvaSt);
            Assert.Equal(0.00m, csosn202.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn202.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn202.ValorIcmsSt);
        }

        [Fact]
        public void TestaCsosn202ComDescontoCondicional()
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

            var csosn202 = new Csosn202(tipoDesconto:TipoDesconto.Condincional);

            csosn202.Calcula(produto);

            Assert.Equal(18.00m, csosn202.PercentualIcmsSt);
            Assert.Equal(40.00m, csosn202.PercentualMvaSt);
            Assert.Equal(0.00m, csosn202.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn202.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn202.ValorIcmsSt);
        }
    }
}