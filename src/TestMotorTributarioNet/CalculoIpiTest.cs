using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoIpiTest
    {
        [TestMethod]
        public void CalcularIpiComQuantidadeUm()
        {
            var produto = new Produto
            {
                PercentualIpi = 17.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(1000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.AreEqual(170.00m, resultadoCalculoIpi.Valor);
        }

        [TestMethod]
        public void CalcularIpiComQuantidadeDois()
        {
            var produto = new Produto
            {
                PercentualIpi = 17.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(4000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.AreEqual(680.00m, resultadoCalculoIpi.Valor);
        }

        [TestMethod]
        public void CalcularIpiComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(5000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.AreEqual(600.00m, resultadoCalculoIpi.Valor);
        }

        [TestMethod]
        public void CalcularIpiComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(3000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.AreEqual(360.00m, resultadoCalculoIpi.Valor);
        }

        [TestMethod]
        public void CalcularIpiComFreteComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(5373.50m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.AreEqual(806.02m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }

        [TestMethod]
        public void CalcularIpiComFreteComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(3373.50m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.AreEqual(506.02m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }

        [TestMethod]
        public void CalcularIpiComOutrasDespesasESeguroComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(5612.33m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.AreEqual(673.48m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }

        [TestMethod]
        public void CalcularIpiComOutrasDespesasESeguroComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.AreEqual(3612.33m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.AreEqual(433.48m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }
    }
}