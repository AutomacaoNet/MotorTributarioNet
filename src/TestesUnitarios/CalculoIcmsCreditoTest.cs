using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoIcmsCreditoTest
    {
        [Fact]
        public void CalcularIcmsCreditoComQuantidadeUm()
        {
            var produto = new Produto
            {
                PercentualCredito = 17.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCredito = facade.CalculaIcmsCredito();

            Assert.Equal(1000.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.Equal(170.00m, resultadoCalculoCredito.Valor);
        }

        [Fact]
        public void CalcularIcmsCreditoComQuantidadeDois()
        {
            var produto = new Produto
            {
                PercentualCredito = 17.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCredito = facade.CalculaIcmsCredito();

            Assert.Equal(4000.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.Equal(680.00m, resultadoCalculoCredito.Valor);
        }

        [Fact]
        public void CalcularIcmsCreditoComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualCredito = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaIcmsCredito();

            Assert.Equal(5000.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.Equal(600.00m, resultadoCalculoCredito.Valor);
        }

        [Fact]
        public void CalcularIcmsCreditoComReducao()
        {
            var produto = new Produto
            {
                PercentualCredito = 7.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaIcmsCredito();

            Assert.Equal(3750.00m, resultadoCalculoCredito.BaseCalculo);
            Assert.Equal(262.5m, resultadoCalculoCredito.Valor);
        }

        [Fact]
        public void CalcularIcmsCreditoComFrete()
        {
            var produto = new Produto
            {
                PercentualCredito = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaIcmsCredito();

            Assert.Equal(4030.12m, decimal.Round(resultadoCalculoCredito.BaseCalculo, 2));
            Assert.Equal(604.52m, decimal.Round(resultadoCalculoCredito.Valor, 2));
        }

        [Fact]
        public void CalcularIcmsComOutrasDespesasESeguro()
        {
            var produto = new Produto
            {
                PercentualCredito = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                PercentualReducao = 25.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoCredito = facade.CalculaIcmsCredito();

            Assert.Equal(4209.25m, decimal.Round(resultadoCalculoCredito.BaseCalculo, 2));
            Assert.Equal(505.11m, decimal.Round(resultadoCalculoCredito.Valor, 2));
        }
    }
}
