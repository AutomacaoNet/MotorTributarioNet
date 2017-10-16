using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoPisTest
    {

        [TestMethod]
        public void CalculoPis()
        {
            
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.AreEqual(1000.00m, resultadoCalculoPis.BaseCalculo);
            Assert.AreEqual(16.50m, resultadoCalculoPis.Valor);
        }

        [TestMethod]
        public void CalculoPisComIpi()
        {

            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 10
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.AreEqual(1010.00m, resultadoCalculoPis.BaseCalculo);
            Assert.AreEqual(16.66m, decimal.Round(resultadoCalculoPis.Valor, 2));
        }

        [TestMethod]
        public void CalculoPisComIpiZero()
        {

            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.AreEqual(1000.00m, resultadoCalculoPis.BaseCalculo);
            Assert.AreEqual(16.50m, resultadoCalculoPis.Valor);
        }

    }
}