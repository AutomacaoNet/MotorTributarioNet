using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using MotorTributarioNet.Util;

namespace TestCalculosTributarios.Cst
{
    [TestClass]
    public class Cst51Test
    {
        [TestMethod]
        public void CalculoCST51()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                PercentualDiferimento = 33.33m

            };

            var cst = new Cst51();
            cst.Calcula(produto);

           
            Assert.AreEqual(1000.00m, cst.ValorBcIcms);
            Assert.AreEqual(18.00m, cst.PercentualIcms);
            Assert.AreEqual(180.00m, cst.ValorIcmsOperacao);
            Assert.AreEqual(33.33m, cst.PercentualDiferimento);
            Assert.AreEqual(60.00m, Math.Round(cst.ValorIcmsDiferido, MidpointRounding.AwayFromZero));
            Assert.AreEqual(120.00m, Math.Round(cst.ValorIcms, MidpointRounding.AwayFromZero));
        }

   
    }
}
