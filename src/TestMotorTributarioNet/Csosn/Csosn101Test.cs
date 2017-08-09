using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios.Csosn
{
    [TestClass]
    public class Csosn101Test
    {

        [TestMethod]
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

            Assert.AreEqual(170.00m, csosn101.ValorCredito);
            Assert.AreEqual(17.00m, csosn101.PercentualCredito);
        }
        [TestMethod]
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

            Assert.AreEqual(153.00m, csosn101.ValorCredito);
            Assert.AreEqual(17.00m, csosn101.PercentualCredito);
        }
        [TestMethod]
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

            Assert.AreEqual(187.00m, csosn101.ValorCredito);
            Assert.AreEqual(17.00m, csosn101.PercentualCredito);
        }
    }
}