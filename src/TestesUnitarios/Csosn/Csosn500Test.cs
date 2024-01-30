using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios.Csosn
{
    public class Csosn500Test
    {

        [Fact]
        public void TestaCalculoICMSEfetivo()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcmsEfetivo = 18.00m,
                PercentualReducaoIcmsEfetivo = 20.00m,
                PercentualFcpStRetido = 2.00m
            };

            var csosn500 = new Csosn500();

            csosn500.Calcula(produto);

            Assert.Equal(800.00m, csosn500.ValorBcIcmsEfetivo);
            Assert.Equal(160.00m, csosn500.ValorIcmsEfetivo);
        }
    }
}