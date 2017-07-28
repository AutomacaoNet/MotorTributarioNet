using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Impostos.Csosns;
using MotorTributarioNet.Impostos.Csosns.Extensao;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios.Csosn
{
    [TestClass]
    public class Csosn101Test
    {
        public void TestaCalculoCsosn101()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 1000
            };

            var csosn101 = new Csosn101 {PercentualCredito = 17.00m};

            csosn101.Calcula(produto);

            Assert.AreEqual(170.00m, produto.ValorProduto);
            Assert.AreEqual(170.00m, csosn101.ValorCredito);
        }
    }
}