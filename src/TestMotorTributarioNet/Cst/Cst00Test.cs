using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;

namespace TestCalculosTributarios.Cst
{
    [TestClass]
    public class Cst00Test
    {
        [TestMethod]
        public void CalculoCST00()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                
            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.AreEqual(180.00m, cst.ValorIcms);
            Assert.AreEqual(18.00m, cst.PercentualIcms);
        }

        [TestMethod]
        public void CalculoCST00ComDesconto()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                Frete = 200m,
                Desconto = 100m

            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.AreEqual(1100.00m, cst.ValorBCIcms);
            Assert.AreEqual(198.00m, cst.ValorIcms);
            Assert.AreEqual(18.00m, cst.PercentualIcms);
        }

        [TestMethod]
        public void CalculoCST00ComFrete()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                Frete = 100m
            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.AreEqual(1100.00m, cst.ValorBCIcms);
            Assert.AreEqual(198.00m, cst.ValorIcms);
            Assert.AreEqual(18.00m, cst.PercentualIcms);
        }

        [TestMethod]
        public void CalculoCST00ComFreteDespesa()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                Frete = 100m,
                OutrasDespesas = 10m,
                Seguro = 10m
            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.AreEqual(1120.00m, cst.ValorBCIcms);
            Assert.AreEqual(201.60m, cst.ValorIcms);
            Assert.AreEqual(18.00m, cst.PercentualIcms);
        }
    }
}
