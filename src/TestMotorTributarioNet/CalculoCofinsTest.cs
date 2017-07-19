using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoCofinsTest
    {

        [TestMethod]
        public void CalculaCofins()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.AreEqual(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.AreEqual(6.50m, resultadoCalculoCofins.Valor);
        }
    }
}