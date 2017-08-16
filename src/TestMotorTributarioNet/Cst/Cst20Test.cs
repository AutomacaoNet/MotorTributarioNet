using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;

namespace TestCalculosTributarios.Cst
{
    [TestClass]
    public class Cst20Test
    {
        [TestMethod]
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
            Assert.AreEqual(10.00m, cst.PercentualReducao);
            Assert.AreEqual(90.00m, cst.ValorBcIcms);            
            Assert.AreEqual(18.00m, cst.PercentualIcms);
            Assert.AreEqual(16.20m, cst.ValorIcms);
        }
    }
}
