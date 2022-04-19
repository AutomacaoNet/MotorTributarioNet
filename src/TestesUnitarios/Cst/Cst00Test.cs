using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst00Test
    {
        [Fact]
        public void CalculoCST00()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                
            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.Equal(180.00m, cst.ValorIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
        }

        [Fact]
        public void CalculoCST00ComDesconto()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                Frete = 200m,
                Desconto = 100m

            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.Equal(1100.00m, cst.ValorBcIcms);
            Assert.Equal(198.00m, cst.ValorIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
        }

        [Fact]
        public void CalculoCST00ComFrete()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                Frete = 100m
            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.Equal(1100.00m, cst.ValorBcIcms);
            Assert.Equal(198.00m, cst.ValorIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
        }

        [Fact]
        public void CalculoCST00ComFreteDespesa()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                Frete = 100m,
                OutrasDespesas = 10m,
                Seguro = 10m
            };

            var cst = new Cst00();
            cst.Calcula(produto);
            Assert.Equal(1120.00m, cst.ValorBcIcms);
            Assert.Equal(201.60m, cst.ValorIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
        }
    }
}
