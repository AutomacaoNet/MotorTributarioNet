using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;

namespace TestCalculosTributarios.Cst
{
    /// <summary>
    /// Descrição resumida para Cst10Test
    /// </summary>
    [TestClass]
    public class Cst10Test
    {
        [TestMethod]
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
            Assert.AreEqual(100.00m, cst.ValorBcIcms);
            Assert.AreEqual(18.00m, cst.PercentualIcms);
            Assert.AreEqual(50.00m, cst.PercentualMva);
            Assert.AreEqual(10.00m, cst.PercentualReducaoSt);
            Assert.AreEqual(135.00m, cst.ValorBcIcmsSt);
            Assert.AreEqual(18.00m, cst.PercentualIcmsSt);
            Assert.AreEqual(6.30m, cst.ValorIcmsSt);

           
        }
    }
}
