using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoIcmsStTest
    {

        [TestMethod]
        public void TestaIcmsSt()
        {
            var produto = new Produto
            {
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            produto.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoCofins = facade.CalculaIcmsSt();

            Assert.AreEqual(2000.00m, resultadoCalculoCofins.BaseCalculoOperacaoPropria);
            Assert.AreEqual(360.00m, resultadoCalculoCofins.ValorIcmsProprio);
            Assert.AreEqual(3220.00m, resultadoCalculoCofins.BaseCalculoIcmsSt);
            Assert.AreEqual(219.60m, resultadoCalculoCofins.ValorIcmsSt);
        }

    }
}