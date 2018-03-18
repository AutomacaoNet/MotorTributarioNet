using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoFcpTest
    {
        [TestMethod]
        public void TestaCalculoFcp()
        {
            var produto = new Produto
            {
                PercentualFcp = 10,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaFcp();

            Assert.AreEqual(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.AreEqual(100.00m, resultadoCalculoCofins.Valor);
        }
    }
}