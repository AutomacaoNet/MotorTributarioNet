using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoPisTest
    {

        [Fact]
        public void CalculoPis()
        {            
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(1000.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(16.50m, resultadoCalculoPis.Valor);
        }

        [Fact]
        public void CalculoPisComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(900.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(14.85m, resultadoCalculoPis.Valor);
        }

        [Fact]
        public void CalculoPisComIpi()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 10
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(1010.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(16.66m, decimal.Round(resultadoCalculoPis.Valor, 2));
        }

        [Fact]
        public void CalculoPisComIpiComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 10,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(910.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(15.02m, decimal.Round(resultadoCalculoPis.Valor, 2));
        }

        [Fact]
        public void CalculoPisComIpiZero()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(1000.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(16.50m, resultadoCalculoPis.Valor);
        }

        [Fact]
        public void CalculoPisComIpiZeroComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(900.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(14.85m, resultadoCalculoPis.Valor);
        }

    }
}