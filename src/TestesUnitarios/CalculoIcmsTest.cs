using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoIcmsTest
    {
        [Fact]
        public void CalcularIcmsComQuantidadeUm()
        {
            var produto = new Produto
            {
                PercentualIcms = 17.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIcms = facade.CalculaIcms();

            Assert.Equal(1000.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.Equal(170.00m, resultadoCalculoIcms.Valor);
        }

        [Fact]
        public void CalcularIcmsComQuantidadeDois()
        {
            var produto = new Produto
            {
                PercentualIcms = 17.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIcms = facade.CalculaIcms();

            Assert.Equal(4000.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.Equal(680.00m, resultadoCalculoIcms.Valor);
        }

        [Fact]
        public void CalcularIcmsComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIcms = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIcms = facade.CalculaIcms();

            Assert.Equal(5000.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.Equal(600.00m, resultadoCalculoIcms.Valor);
        }

        [Fact]
        public void CalcularIcmsComReducao()
        {
            var produto = new Produto
            {
                PercentualIcms = 7.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIcms = facade.CalculaIcms();

            Assert.Equal(3750.00m, resultadoCalculoIcms.BaseCalculo);
            Assert.Equal(262.5m, resultadoCalculoIcms.Valor);
        }

        [Fact]
        public void CalcularIcmsComFrete()
        {
            var produto = new Produto
            {
                PercentualIcms = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIcms = facade.CalculaIcms();

            Assert.Equal(4030.12m, decimal.Round(resultadoCalculoIcms.BaseCalculo, 2));
            Assert.Equal(604.52m, decimal.Round(resultadoCalculoIcms.Valor, 2));
        }

        [Fact]
        public void CalcularIcmsComOutrasDespesasESeguro()
        {
            var produto = new Produto
            {
                PercentualIcms = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIcms = facade.CalculaIcms();

            Assert.Equal(4209.25m, decimal.Round(resultadoCalculoIcms.BaseCalculo, 2));
            Assert.Equal(505.11m, decimal.Round(resultadoCalculoIcms.Valor, 2));
        }
    }
}