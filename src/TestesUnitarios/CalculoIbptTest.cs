using MotorTributarioNet.Facade;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoIbptTest
    {
        [Fact]
        public void CalculaIbpt()
        {

            // produto implementou a interface IIbpt é ITributavel
            var produto = new Produto
            {
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualFederal = 10,
                PercentualFederalImportados = 20,
                PercentualEstadual = 15,
                PercentualMunicipal = 0
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaIbpt(produto);

            Assert.Equal(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(100, resultadoCalculoCofins.TributacaoFederal);
            Assert.Equal(200, resultadoCalculoCofins.TributacaoFederalImportados);
            Assert.Equal(150, resultadoCalculoCofins.TributacaoEstadual);
            Assert.Equal(0, resultadoCalculoCofins.TributacaoMunicipal);
        }
    }
}