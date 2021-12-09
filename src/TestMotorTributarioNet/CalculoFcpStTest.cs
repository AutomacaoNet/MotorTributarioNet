using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoFcpStTest
    {
        [TestMethod]
        public void TestaFcpSt_Valor_56()
        {
            var produto = new Produto
            {
                PercentualFcpSt = 2.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIcmsSt = facade.CalculaFcpSt();
            
            Assert.AreEqual(56.00m, resultadoCalculoIcmsSt.ValorFcpSt);
        }
        
        [TestMethod] // https://portalspedbrasil.com.br/forum/fundo-do-combate-a-probreza-icms-normal-e-fcp-st/
        public void TestFcpSt_Valor_2_60()
        {
            var produto = new Produto
            {
                PercentualFcpSt = 2.00m,
                ValorProduto = 100.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 30.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIcmsSt = facade.CalculaFcpSt();

            Assert.AreEqual(2.60m, resultadoCalculoIcmsSt.ValorFcpSt);
        }

        [TestMethod]
        public void TestaFcpSt_ComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualFcpSt = 2.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m,
                Desconto = 200.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIcmsSt = facade.CalculaFcpSt();

            Assert.AreEqual(2520.00m, resultadoCalculoIcmsSt.BaseCalculoFcpSt);
            Assert.AreEqual(50.40m, resultadoCalculoIcmsSt.ValorFcpSt);
        }
    }
}