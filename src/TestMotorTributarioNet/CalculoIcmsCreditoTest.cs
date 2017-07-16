using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoIcmsCreditoTest
    {
        [TestMethod]
        public void CalcularIcmsCreditoComQuantidadeUm()
        {
            var produto = new Produto
            {
                PercentualCredito = 17.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCredito = facade.CalculaCredito();

            Assert.AreEqual(1000.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.AreEqual(170.00m, resultadoCalculoCredito.Valor);
        }

        [TestMethod]
        public void CalcularIcmsCreditoComQuantidadeDois()
        {
            var produto = new Produto
            {
                PercentualCredito = 17.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCredito = facade.CalculaCredito();

            Assert.AreEqual(4000.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.AreEqual(680.00m, resultadoCalculoCredito.Valor);
        }

        [TestMethod]
        public void CalcularIcmsCreditoComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualCredito = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaCredito();

            Assert.AreEqual(5000.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.AreEqual(600.00m, resultadoCalculoCredito.Valor);
        }

        [TestMethod]
        public void CalcularIcmsCreditoComReducao()
        {
            var produto = new Produto
            {
                PercentualCredito = 7.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaCredito();

            Assert.AreEqual(3750.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.AreEqual(262.5m, resultadoCalculoCredito.Valor);
        }

        [TestMethod]
        public void CalcularIcmsCreditoComFrete()
        {
            var produto = new Produto
            {
                PercentualCredito = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaCredito();

            Assert.AreEqual(4030.12m, decimal.Round(resultadoCalculoCredito.BaseCalculo, 2));
            Assert.AreEqual(604.52m, decimal.Round(resultadoCalculoCredito.Valor, 2));
        }

        [TestMethod]
        public void CalcularIcmsComOutrasDespesasESeguro()
        {
            var produto = new Produto
            {
                PercentualCredito = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaCredito();

            Assert.AreEqual(4209.25m, decimal.Round(resultadoCalculoCredito.BaseCalculo, 2));
            Assert.AreEqual(505.11m, decimal.Round(resultadoCalculoCredito.Valor, 2));
        }
    }
}
