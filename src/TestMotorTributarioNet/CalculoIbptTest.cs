using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoIbptTest
    {
        [TestMethod]
        public void CalculaIbpt()
        {

            // produto implementou a interface IIbpt é ITributavel
            var produto = new Produto
            {
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualFederal = 10,
                PercentualFederalImportados = 20,
                PercentualEstadual = 15,
                PercentualMunicipal = 0
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaIbpt(produto);

            Assert.AreEqual(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.AreEqual(100, resultadoCalculoCofins.TributacaoFederal);
            Assert.AreEqual(200, resultadoCalculoCofins.TributacaoFederalImportados);
            Assert.AreEqual(150, resultadoCalculoCofins.TributacaoEstadual);
            Assert.AreEqual(0, resultadoCalculoCofins.TributacaoMunicipal);
        }
    }
}