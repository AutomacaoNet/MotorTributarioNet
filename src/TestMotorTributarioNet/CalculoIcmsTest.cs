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

            FacadeCalculadoraTributacao.ProcessamentoDeIcms(new TributacaoIcms(produto, TipoDesconto.Incondicional));

            Assert.AreEqual(1000, produto.BaseCalculoIcms);
            Assert.AreEqual(170, produto.ValorIcms);
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

            FacadeCalculadoraTributacao.ProcessamentoDeIcms(new TributacaoIcms(produto, TipoDesconto.Incondicional));

            Assert.AreEqual(4000, produto.BaseCalculoIcms);
            Assert.AreEqual(680, produto.ValorIcms);
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

            FacadeCalculadoraTributacao.ProcessamentoDeIcms(new TributacaoIcms(produto, TipoDesconto.Condincional));

            Assert.AreEqual(5000, produto.BaseCalculoIcms);
            Assert.AreEqual(600, produto.ValorIcms);
        }
    }
}