using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios.Cst
{
    [TestClass]
    public class Cst60Test
    {
        [TestMethod]
        public void CalculaCST60()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
            };

            var cst = new Cst60();
            cst.Calcula(produto);

            Assert.AreEqual(18.00m, cst.PercentualBcStRetido);
            Assert.AreEqual(1000.00m, cst.ValorBcStRetido);
        }

        [TestMethod]
        public void CalculaCST60_CTe()
        {
            var produtoFrete = new Produto
            {
                Documento = Documento.CTe,
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                PercentualCredito = 20.00m
            };

            var cst = new Cst60();
            cst.Calcula(produtoFrete);

            Assert.AreEqual(18.00m, cst.PercentualBcStRetido);
            Assert.AreEqual(1000.00m, cst.ValorBcStRetido);
            Assert.AreEqual(36.00m, cst.ValorCreditoOutorgadoOuPresumido);
        }
    }
}