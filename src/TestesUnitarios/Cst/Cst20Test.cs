using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst20Test
    {
        [Fact]
        public void CalculoCST20()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 100.00m,
                PercentualIcms = 18.00m,
                PercentualReducao = 10.00m

            };

            var cst = new Cst20();
            cst.Calcula(produto);
            Assert.Equal(10.00m, cst.PercentualReducao);
            Assert.Equal(90.00m, cst.ValorBcIcms);            
            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(16.20m, cst.ValorIcms);
        }
    }
}
