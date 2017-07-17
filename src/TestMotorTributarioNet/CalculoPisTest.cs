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
                PercentualIcms = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.AreEqual(1000.00m, resultadoCalculoPis.BaseCalculo);
            Assert.AreEqual(16.50m, resultadoCalculoPis.Valor);
        }

    }
}