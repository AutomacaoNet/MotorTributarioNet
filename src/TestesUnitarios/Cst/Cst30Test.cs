using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst30Test
    {
        [Fact]
        public void CalculoCST30()
        {

            var produto = new Produto
            {
                
                PercentualIcmsSt = 18.00m,
                ValorProduto = 100.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 50.00m,
                PercentualReducaoSt = 10m

            };

            var cst = new Cst30();
            cst.Calcula(produto);

            
            Assert.Equal(50.00m, cst.PercentualMva);
            Assert.Equal(10.00m, cst.PercentualReducaoSt);
            Assert.Equal(135.00m, cst.ValorBcIcmsSt);
            Assert.Equal(18.00m, cst.PercentualIcmsSt);
            Assert.Equal(24.30m, cst.ValorIcmsSt);
        }
    }
}
