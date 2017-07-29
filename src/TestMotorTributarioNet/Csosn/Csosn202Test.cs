using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios.Csosn
{
    [TestClass]
    public class Csosn202Test
    {
        [TestMethod]
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

            Assert.AreEqual(18.00m, csosn202.PercentualIcmsSt);
            Assert.AreEqual(40.00m, csosn202.PercentualMvaSt);
            Assert.AreEqual(0.00m, csosn202.PercentualReducaoSt);
            Assert.AreEqual(3220.00m, csosn202.ValorBcIcmsSt);
            Assert.AreEqual(219.60m, csosn202.ValorIcmsSt);
        }
    }
}