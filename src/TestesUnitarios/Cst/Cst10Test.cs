using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst10Test
    {
        [Fact]
        public void CalculoCST10()
        {
            var produto = new Produto
            {

                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,               
                ValorProduto = 100.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 50.00m,
                PercentualReducaoSt = 10m

            };

            var cst = new Cst10();
            cst.Calcula(produto);
            Assert.Equal(100.00m, cst.ValorBcIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(50.00m, cst.PercentualMva);
            Assert.Equal(10.00m, cst.PercentualReducaoSt);
            Assert.Equal(135.00m, cst.ValorBcIcmsSt);
            Assert.Equal(18.00m, cst.PercentualIcmsSt);
            Assert.Equal(6.30m, cst.ValorIcmsSt);

           
        }
    }
}
