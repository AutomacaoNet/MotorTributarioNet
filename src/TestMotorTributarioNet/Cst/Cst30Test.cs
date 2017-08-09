using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;

namespace TestCalculosTributarios.Cst
{
    [TestClass]
    public class Cst30Test
    {
        [TestMethod]
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

            
            Assert.AreEqual(50.00m, cst.PercentualMva);
            Assert.AreEqual(10.00m, cst.PercentualReducaoSt);
            Assert.AreEqual(135.00m, cst.ValorBcIcmsSt);
            Assert.AreEqual(18.00m, cst.PercentualIcmsSt);
            Assert.AreEqual(24.30m, cst.ValorIcmsSt);
        }
    }
}
