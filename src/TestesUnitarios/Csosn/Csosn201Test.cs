using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios.Csosn
{
    public class Csosn201Test
    {
        [Fact]
        public void TestaCsosn201()
        {
            var produto = new Produto
            {
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m,
                PercentualCredito = 5.00m
            };

            var csosn201 = new Csosn201();

            csosn201.Calcula(produto);

            Assert.Equal(18.00m, csosn201.PercentualIcmsSt);
            Assert.Equal(5.00m, csosn201.PercentualCredito);
            Assert.Equal(40.00m, csosn201.PercentualMva);
            Assert.Equal(0.00m, csosn201.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn201.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn201.ValorIcmsSt);
            Assert.Equal(100.00m, csosn201.ValorCredito);
        }

        [Fact]
        public void TestaCsosn201ComDescontoCondicional()
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
                PercentualCredito = 5.00m
            };

            var csosn201 = new Csosn201(tipoDesconto:TipoDesconto.Condincional);

            csosn201.Calcula(produto);

            Assert.Equal(18.00m, csosn201.PercentualIcmsSt);
            Assert.Equal(5.00m, csosn201.PercentualCredito);
            Assert.Equal(40.00m, csosn201.PercentualMva);
            Assert.Equal(0.00m, csosn201.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn201.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn201.ValorIcmsSt);
            Assert.Equal(100.00m, csosn201.ValorCredito);
        }
    }
}