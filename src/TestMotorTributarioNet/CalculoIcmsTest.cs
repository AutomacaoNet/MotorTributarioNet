using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoIcmsTest
    {
        [TestMethod]
        public void CalcularIcmsComQuantidadeUm()
        {
            var produto = new Produto
            {
                PercentualIcms = 17.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.CalculaIcms(produto, TipoDesconto.Incondicional);

            Assert.AreEqual(1000.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.AreEqual(170.00m, resultadoCalculoIcms.Valor);
        }

        [TestMethod]
        public void CalcularIcmsComQuantidadeDois()
        {
            var produto = new Produto
            {
                PercentualIcms = 17.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.CalculaIcms(produto, TipoDesconto.Incondicional);

            Assert.AreEqual(4000.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.AreEqual(680.00m, resultadoCalculoIcms.Valor);
        }

        [TestMethod]
        public void CalcularIcmsComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIcms = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.CalculaIcms(produto, TipoDesconto.Condincional);

            Assert.AreEqual(5000.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.AreEqual(600.00m, resultadoCalculoIcms.Valor);
        }

        [TestMethod]
        public void CalcularIcmsComReducao()
        {
            var produto = new Produto
            {
                PercentualIcms = 7.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.CalculaIcms(produto, TipoDesconto.Condincional);

            Assert.AreEqual(3750.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.AreEqual(262.5m, resultadoCalculoIcms.Valor);
        }

        [TestMethod]
        public void CalcularIcmsComFrete()
        {
            var produto = new Produto
            {
                PercentualIcms = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.CalculaIcms(produto, TipoDesconto.Condincional);

            Assert.AreEqual(4030.12m, decimal.Round(resultadoCalculoIcms.BaseCalculo, 2));
            Assert.AreEqual(604.52m, decimal.Round(resultadoCalculoIcms.Valor, 2));
        }

        [TestMethod]
        public void CalcularIcmsComOutrasDespesasESeguro()
        {
            var produto = new Produto
            {
                PercentualIcms = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.CalculaIcms(produto, TipoDesconto.Condincional);

            Assert.AreEqual(4209.25m, decimal.Round(resultadoCalculoIcms.BaseCalculo, 2));
            Assert.AreEqual(505.11m, decimal.Round(resultadoCalculoIcms.Valor, 2));
        }
    }
}