using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Componentes;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoIcmsTest
    {


        [TestMethod]
        public void CalcularIcmsComQuantidadeUm()
        {
            var produto = new Produto
            {
                PercentualIcms = 17.00m,
                ValorProduto = 1000,
                QuantidadeProduto = 1
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.ProcessamentoDeIcms(new TributacaoIcms(produto, TipoDesconto.Incondicional));

            Assert.AreEqual(1000, resultadoCalculoIcms.BaseCalculo);
            Assert.AreEqual(170, resultadoCalculoIcms.Valor);
        }

        [TestMethod]
        public void CalcularIcmsComQuantidadeDois()
        {
            var produto = new Produto
            {
                PercentualIcms = 17.00m,
                ValorProduto = 2000,
                QuantidadeProduto = 2
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.ProcessamentoDeIcms(new TributacaoIcms(produto, TipoDesconto.Incondicional));

            Assert.AreEqual(4000, resultadoCalculoIcms.BaseCalculo);
            Assert.AreEqual(680, resultadoCalculoIcms.Valor);
        }

        [TestMethod]
        public void CalcularIcmsComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIcms = 12.00m,
                ValorProduto = 2000,
                QuantidadeProduto = 2,
                Desconto = 1000
            };

            var resultadoCalculoIcms = FacadeCalculadoraTributacao.ProcessamentoDeIcms(new TributacaoIcms(produto, TipoDesconto.Condincional));

            Assert.AreEqual(5000, resultadoCalculoIcms.BaseCalculo);
            Assert.AreEqual(600, resultadoCalculoIcms.Valor);
        }
    }
}