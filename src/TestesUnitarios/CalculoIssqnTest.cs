using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;


namespace TestCalculosTributarios
{
    public class CalculoIssqnTest
    {
        [Fact]
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

            Assert.Equal(1000.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.Equal(50.00m, resultadoCalculoIssqn.Valor);
        }

        [Fact]
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

            Assert.Equal(900.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.Equal(45.00m, resultadoCalculoIssqn.Valor);
        }

        [Fact]
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

            Assert.Equal(1000.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.Equal(50.00m, resultadoCalculoIssqn.Valor);

            Assert.Equal(1000.00m, resultadoCalculoIssqn.BaseCalculoInss);
            Assert.Equal(1000.00m, resultadoCalculoIssqn.BaseCalculoIrrf);

            Assert.Equal(16.50m, resultadoCalculoIssqn.ValorRetIrrf);
            Assert.Equal(30.00m, resultadoCalculoIssqn.ValorRetCofins);
            Assert.Equal(6.50m, resultadoCalculoIssqn.ValorRetPis);
            Assert.Equal(110.00m, resultadoCalculoIssqn.ValorRetInss);
            Assert.Equal(10.00m, resultadoCalculoIssqn.ValorRetCsll);
        }

        [Fact]
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

            Assert.Equal(900.00m, resultadoCalculoIssqn.BaseCalculo);
            Assert.Equal(45.00m, resultadoCalculoIssqn.Valor);

            Assert.Equal(900.00m, resultadoCalculoIssqn.BaseCalculoInss);
            Assert.Equal(900.00m, resultadoCalculoIssqn.BaseCalculoIrrf);

            Assert.Equal(14.85m, resultadoCalculoIssqn.ValorRetIrrf);
            Assert.Equal(27.00m, resultadoCalculoIssqn.ValorRetCofins);
            Assert.Equal(5.85m, resultadoCalculoIssqn.ValorRetPis);
            Assert.Equal(99.00m, resultadoCalculoIssqn.ValorRetInss);
            Assert.Equal(9.00m, resultadoCalculoIssqn.ValorRetCsll);
        }
    }
}
