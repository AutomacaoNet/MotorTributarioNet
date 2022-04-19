using MotorTributarioNet.Facade;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoIcmsStTest
    {

        [Fact]
        public void TestaIcmsSt()
        {
            var produto = new Produto
            {
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            produto.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoIcmsSt = facade.CalculaIcmsSt();

            Assert.Equal(2000.00m, resultadoCalculoIcmsSt.BaseCalculoOperacaoPropria);
            Assert.Equal(360.00m, resultadoCalculoIcmsSt.ValorIcmsProprio);
            Assert.Equal(3220.00m, resultadoCalculoIcmsSt.BaseCalculoIcmsSt);
            Assert.Equal(219.60m, resultadoCalculoIcmsSt.ValorIcmsSt);
        }

        [Fact]
        public void TestaIcmsStValorSt()
        {
            var produto = new Produto
            {
                ValorProduto = 10000.00m,
                Frete = 80.00m,
                Seguro = 20.00m,
                PercentualIcms = 7.00m,
                PercentualIcmsSt = 18.00m,
                PercentualMva = 40.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIcmsSt = facade.CalculaIcmsSt();

            Assert.Equal(1838.20m, resultadoCalculoIcmsSt.ValorIcmsSt);
        }

    }
}