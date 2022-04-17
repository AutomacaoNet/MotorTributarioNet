using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios.Csosn
{
    public class Csosn101Test
    {

        [Fact]
        public void TestaCalculoCsosn101()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualCredito = 17.00m 
            };

            var csosn101 = new Csosn101();

            csosn101.Calcula(produto);

            Assert.Equal(170.00m, csosn101.ValorCredito);
            Assert.Equal(17.00m, csosn101.PercentualCredito);
        }

        [Fact]
        public void TestaCalculoCsosn101ComDescontoIncodicional()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualCredito = 17.00m,
                Desconto = 100m

            };

            var csosn101 = new Csosn101();

            csosn101.Calcula(produto);

            Assert.Equal(153.00m, csosn101.ValorCredito);
            Assert.Equal(17.00m, csosn101.PercentualCredito);
        }

        [Fact]
        public void TestaCalculoCsosn101ComDescontoCondicional()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualCredito = 17.00m,
                Desconto = 100m

            };

            var csosn101 = new Csosn101(tipoDesconto:TipoDesconto.Condincional);

            csosn101.Calcula(produto);

            Assert.Equal(187.00m, csosn101.ValorCredito);
            Assert.Equal(17.00m, csosn101.PercentualCredito);
        }
    }
}