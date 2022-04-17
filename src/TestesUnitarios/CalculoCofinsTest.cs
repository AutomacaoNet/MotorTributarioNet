using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoCofinsTest
    {

        [Fact]
        public void CalculaCofins()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(6.50m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void CalculaCofinsComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(900.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(5.85m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void CalculaCofinsMaisIpi()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 10
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(1010.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(6.56m, decimal.Round(resultadoCalculoCofins.Valor, 2));
        }

        [Fact]
        public void CalculaCofinsMaisIpiComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 10,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(910.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(5.92m, decimal.Round(resultadoCalculoCofins.Valor, 2));
        }

        [Fact]
        public void CalculaCofinsComIpiZero()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(6.50m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void CalculaCofinsComIpiZeroComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(900.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(5.85m, resultadoCalculoCofins.Valor);
        }
    }
}