using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;


namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoIssqnTest
    {
        [TestMethod]
        public void CalculoIssqn()
        {
            var produto = new Produto
            {
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = true,
                PercentualIssqn = 5.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIssqn = facade.CalculaIssqn(false);

            Assert.AreEqual(1000.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.AreEqual(50.00m, resultadoCalculoIssqn.Valor);
        }

        [TestMethod]
        public void CalculoIssqnComDescontoIncondicional()
        {
            var produto = new Produto
            {
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = true,
                PercentualIssqn = 5.00m,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIssqn = facade.CalculaIssqn(false);

            Assert.AreEqual(900.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.AreEqual(45.00m, resultadoCalculoIssqn.Valor);
        }

        [TestMethod]
        public void CalculoIssqnComRetencao()
        {
            var produto = new Produto
            {

                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = true,
                PercentualIssqn = 5.00m,

                PercentualRetIrrf = 1.65m,
                PercentualRetCsll = 1.00m,
                PercentualRetCofins = 3.00m,
                PercentualRetPis = 0.65m,
                PercentualRetInss = 11.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIssqn = facade.CalculaIssqn(true);

            Assert.AreEqual(1000.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.AreEqual(50.00m, resultadoCalculoIssqn.Valor);

            Assert.AreEqual(1000.00m, resultadoCalculoIssqn.BaseCalculoInss);
            Assert.AreEqual(1000.00m, resultadoCalculoIssqn.BaseCalculoIrrf);

            Assert.AreEqual(16.50m, resultadoCalculoIssqn.ValorRetIrrf);
            Assert.AreEqual(30.00m, resultadoCalculoIssqn.ValorRetCofins);
            Assert.AreEqual(6.50m, resultadoCalculoIssqn.ValorRetPis);
            Assert.AreEqual(110.00m, resultadoCalculoIssqn.ValorRetInss);
            Assert.AreEqual(10.00m, resultadoCalculoIssqn.ValorRetCsll);
        }

        [TestMethod]
        public void CalculoIssqnComRetencaoComDescontoIncondicional()
        {
            var produto = new Produto
            {

                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = true,
                PercentualIssqn = 5.00m,
                Desconto = 100.00m,

                PercentualRetIrrf = 1.65m,
                PercentualRetCsll = 1.00m,
                PercentualRetCofins = 3.00m,
                PercentualRetPis = 0.65m,
                PercentualRetInss = 11.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIssqn = facade.CalculaIssqn(true);

            Assert.AreEqual(900.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.AreEqual(45.00m, resultadoCalculoIssqn.Valor);

            Assert.AreEqual(900.00m, resultadoCalculoIssqn.BaseCalculoInss);
            Assert.AreEqual(900.00m, resultadoCalculoIssqn.BaseCalculoIrrf);

            Assert.AreEqual(14.85m, resultadoCalculoIssqn.ValorRetIrrf);
            Assert.AreEqual(27.00m, resultadoCalculoIssqn.ValorRetCofins);
            Assert.AreEqual(5.85m, resultadoCalculoIssqn.ValorRetPis);
            Assert.AreEqual(99.00m, resultadoCalculoIssqn.ValorRetInss);
            Assert.AreEqual(9.00m, resultadoCalculoIssqn.ValorRetCsll);
        }
    }
}
