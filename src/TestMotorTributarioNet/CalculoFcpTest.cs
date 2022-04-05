using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
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

        [TestMethod]
        public void TestaCalculoFcpComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualFcp = 10,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCofins = facade.CalculaFcp();

            Assert.AreEqual(900.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.AreEqual(90.00m, resultadoCalculoCofins.Valor);
        }
    }
}