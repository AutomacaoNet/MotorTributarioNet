using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios.Csosn
{
    [TestClass]
    public class Csosn201Test
    {
        [TestMethod]
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

            Assert.AreEqual(18.00m, csosn201.PercentualIcmsSt);
            Assert.AreEqual(5.00m, csosn201.PercentualCredito);
            Assert.AreEqual(40.00m, csosn201.PercentualMva);
            Assert.AreEqual(0.00m, csosn201.PercentualReducaoSt);
            Assert.AreEqual(3220.00m, csosn201.ValorBcIcmsSt);
            Assert.AreEqual(219.60m, csosn201.ValorIcmsSt);
            Assert.AreEqual(100.00m, csosn201.ValorCredito);
        }
    }
}