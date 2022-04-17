using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoFcpTest
    {
        [Fact]
        public void TestaCalculoFcp()
        {
            var produto = new Produto
            {
                PercentualFcp = 10,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaFcp();

            Assert.Equal(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(100.00m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void TestaCalculoFcpComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualFcp = 10,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCofins = facade.CalculaFcp();

            Assert.Equal(900.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(90.00m, resultadoCalculoCofins.Valor);
        }
    }
}