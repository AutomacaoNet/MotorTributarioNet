using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns;
using MotorTributarioNet.Util;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios.Csosn
{
    [TestClass]
    public class Csosn900Test
    {
        [TestMethod]
        public void TestaCsosn900()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 2000.00m,
                PercentualCredito = 17.00m,
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                PercentualMva = 40.00m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(391.00m, csosn900.ValorCredito);
            Assert.AreEqual(17.00m, csosn900.PercentualCredito);
            Assert.AreEqual(18.00m, csosn900.PercentualIcmsSt);
            Assert.AreEqual(40.00m, csosn900.PercentualMva);
            Assert.AreEqual(0.00m, csosn900.PercentualReducaoSt);
            Assert.AreEqual(3220.00m, csosn900.ValorBcIcmsSt);
            Assert.AreEqual(219.60m, csosn900.ValorIcmsSt);
            Assert.AreEqual(414.00m, csosn900.ValorIcms);
            Assert.AreEqual(2300.00m, csosn900.ValorBcIcms);
        }

        [TestMethod]
        public void TestaCsosn900ComDescontoCondicional()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1900.00m,
                Desconto = 100m,
                PercentualCredito = 17.00m,
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                PercentualMva = 40.00m
            };

            var csosn900 = new Csosn900(tipoDesconto:TipoDesconto.Condincional);

            csosn900.Calcula(produto);

            Assert.AreEqual(391.00m, csosn900.ValorCredito);
            Assert.AreEqual(17.00m, csosn900.PercentualCredito);
            Assert.AreEqual(18.00m, csosn900.PercentualIcmsSt);
            Assert.AreEqual(40.00m, csosn900.PercentualMva);
            Assert.AreEqual(0.00m, csosn900.PercentualReducaoSt);
            Assert.AreEqual(3220.00m, csosn900.ValorBcIcmsSt);
            Assert.AreEqual(219.60m, csosn900.ValorIcmsSt);
            Assert.AreEqual(414.00m, csosn900.ValorIcms);
            Assert.AreEqual(2300.00m, csosn900.ValorBcIcms);
        }

        [TestMethod]
        public void TestaCsosn900ComReducaoSt()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 2000.00m,
                PercentualCredito = 17.00m,
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualIpi = 15.00m,
                PercentualMva = 40.00m,
                PercentualReducaoSt = 10.00m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(391.00m, csosn900.ValorCredito);
            Assert.AreEqual(17.00m, csosn900.PercentualCredito);
            Assert.AreEqual(18.00m, csosn900.PercentualIcmsSt);
            Assert.AreEqual(40.00m, csosn900.PercentualMva);
            Assert.AreEqual(10.00m, csosn900.PercentualReducaoSt);
            Assert.AreEqual(2898.00m, csosn900.ValorBcIcmsSt);
            Assert.AreEqual(161.64m, csosn900.ValorIcmsSt);
            Assert.AreEqual(414.00m, csosn900.ValorIcms);
            Assert.AreEqual(2300.00m, csosn900.ValorBcIcms);
        }

        [TestMethod]
        public void Testa__Percentual12__ProdutoValor38()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 38.00m,
                PercentualIcms = 12.00m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(4.56m, csosn900.ValorIcms.Arredondar());
        }

        [TestMethod]
        public void Testa__IcmsST_16Porcento()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 38.00m,
                PercentualIcms = 12.00m,
                PercentualIcmsSt = 16.00m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(1.52m, csosn900.ValorIcmsSt.Arredondar());
        }

        [TestMethod]
        public void Testa_IcmsST_ComIPI()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 38.00m,
                PercentualIcms = 12.00m,
                PercentualIcmsSt = 16.00m,
                PercentualIpi = 15.00m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(2.43m, csosn900.ValorIcmsSt.Arredondar());
        }

        [TestMethod]
        public void Testa_IcmsST_ComIPI_ComDesconto()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 38.00m,
                PercentualIcms = 12.00m,
                PercentualIcmsSt = 16.00m,
                PercentualIpi = 15.00m,
                Desconto = 2.53m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(2.27m, csosn900.ValorIcmsSt.Arredondar());
        }

        [TestMethod]
        public void Testa_IcmsST_ComIPI_ComDesconto_ComMVA()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 38.00m,
                PercentualIcms = 12.00m,
                PercentualIcmsSt = 16.00m,
                PercentualIpi = 15.00m,
                Desconto = 2.53m,
                PercentualMva = 50.00m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(5.53m, csosn900.ValorIcmsSt.Arredondar());
        }

        [TestMethod]
        public void Testa_IcmsST_ComIPI_ComDesconto_ComMVA_ResultadoBaseCalculoST()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 38.00m,
                PercentualIcms = 12.00m,
                PercentualIcmsSt = 16.00m,
                PercentualIpi = 15.00m,
                Desconto = 2.53m,
                PercentualMva = 50.00m
            };

            var csosn900 = new Csosn900();

            csosn900.Calcula(produto);

            Assert.AreEqual(61.19m, csosn900.ValorBcIcmsSt.Arredondar());
        }
    }
}