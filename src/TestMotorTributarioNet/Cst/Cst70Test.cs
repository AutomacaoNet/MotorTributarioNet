using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using MotorTributarioNet.Flags;

namespace TestCalculosTributarios.Cst
{
    [TestClass]
    public class Cst70Test
    {
        [TestMethod]
        public void CalculoCst70()
        {
            var produto = new Produto
            {

                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualReducao = 10.00m,
                ValorProduto = 100.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 100.00m,
                PercentualReducaoSt = 10m

            };

            var cst = new Cst70();
            cst.Calcula(produto);
            Assert.AreEqual(ModalidadeDeterminacaoBcIcms.ValorOperacao, cst.ModalidadeDeterminacaoBcIcms);
            Assert.AreEqual(10.00m, cst.PercentualReducao);
            Assert.AreEqual(90.00m, cst.ValorBcIcms);
            Assert.AreEqual(18.00m, cst.PercentualIcms);
            Assert.AreEqual(16.20m, cst.ValorIcms);
            Assert.AreEqual(ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado, cst.ModalidadeDeterminacaoBcIcmsSt);
            Assert.AreEqual(100.00m, cst.PercentualMva);
            Assert.AreEqual(10.00m, cst.PercentualReducaoSt);
            Assert.AreEqual(162.00m, cst.ValorBcIcmsSt);
            Assert.AreEqual(18.00m, cst.PercentualIcmsSt);
            Assert.AreEqual(12.96m, cst.ValorIcmsSt);
        }
    }
}
