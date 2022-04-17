using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoIpiTest
    {
        [Fact]
        public void CalcularIpiComQuantidadeUm()
        {
            var produto = new Produto
            {
                PercentualIpi = 17.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(1000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.Equal(170.00m, resultadoCalculoIpi.Valor);
        }

        [Fact]
        public void CalcularIpiComQuantidadeDois()
        {
            var produto = new Produto
            {
                PercentualIpi = 17.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(4000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.Equal(680.00m, resultadoCalculoIpi.Valor);
        }

        [Fact]
        public void CalcularIpiComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(5000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.Equal(600.00m, resultadoCalculoIpi.Valor);
        }

        [Fact]
        public void CalcularIpiComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000.00m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(3000.00m, resultadoCalculoIpi.BaseCalculo);
            Assert.Equal(360.00m, resultadoCalculoIpi.Valor);
        }

        [Fact]
        public void CalcularIpiComFreteComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(5373.50m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.Equal(806.02m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }

        [Fact]
        public void CalcularIpiComFreteComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 15.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(3373.50m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.Equal(506.02m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }

        [Fact]
        public void CalcularIpiComOutrasDespesasESeguroComDescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Condincional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(5612.33m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.Equal(673.48m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }

        [Fact]
        public void CalcularIpiComOutrasDespesasESeguroComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualIpi = 12.00m,
                ValorProduto = 2000m,
                QuantidadeProduto = 2.000m,
                Desconto = 1000.00m,
                Frete = 373.50m,
                OutrasDespesas = 233.10m,
                Seguro = 5.73m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIpi = facade.CalculaIpi();

            Assert.Equal(3612.33m, decimal.Round(resultadoCalculoIpi.BaseCalculo, 2));
            Assert.Equal(433.48m, decimal.Round(resultadoCalculoIpi.Valor, 2));
        }
    }
}