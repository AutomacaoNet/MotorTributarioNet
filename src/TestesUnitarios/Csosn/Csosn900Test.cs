using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns;
using MotorTributarioNet.Util;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios.Csosn
{
    public class Csosn900Test
    {
        [Fact]
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

            Assert.Equal(391.00m, csosn900.ValorCredito);
            Assert.Equal(17.00m, csosn900.PercentualCredito);
            Assert.Equal(18.00m, csosn900.PercentualIcmsSt);
            Assert.Equal(40.00m, csosn900.PercentualMva);
            Assert.Equal(0.00m, csosn900.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn900.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn900.ValorIcmsSt);
            Assert.Equal(414.00m, csosn900.ValorIcms);
            Assert.Equal(2300.00m, csosn900.ValorBcIcms);
        }

        [Fact]
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

            Assert.Equal(391.00m, csosn900.ValorCredito);
            Assert.Equal(17.00m, csosn900.PercentualCredito);
            Assert.Equal(18.00m, csosn900.PercentualIcmsSt);
            Assert.Equal(40.00m, csosn900.PercentualMva);
            Assert.Equal(0.00m, csosn900.PercentualReducaoSt);
            Assert.Equal(3220.00m, csosn900.ValorBcIcmsSt);
            Assert.Equal(219.60m, csosn900.ValorIcmsSt);
            Assert.Equal(414.00m, csosn900.ValorIcms);
            Assert.Equal(2300.00m, csosn900.ValorBcIcms);
        }

        [Fact]
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

            Assert.Equal(391.00m, csosn900.ValorCredito);
            Assert.Equal(17.00m, csosn900.PercentualCredito);
            Assert.Equal(18.00m, csosn900.PercentualIcmsSt);
            Assert.Equal(40.00m, csosn900.PercentualMva);
            Assert.Equal(10.00m, csosn900.PercentualReducaoSt);
            Assert.Equal(2898.00m, csosn900.ValorBcIcmsSt);
            Assert.Equal(161.64m, csosn900.ValorIcmsSt);
            Assert.Equal(414.00m, csosn900.ValorIcms);
            Assert.Equal(2300.00m, csosn900.ValorBcIcms);
        }

        [Fact]
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

            Assert.Equal(4.56m, csosn900.ValorIcms.Arredondar());
        }

        [Fact]
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

            Assert.Equal(1.52m, csosn900.ValorIcmsSt.Arredondar());
        }

        [Fact]
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

            Assert.Equal(2.43m, csosn900.ValorIcmsSt.Arredondar());
        }

        [Fact]
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

            Assert.Equal(2.27m, csosn900.ValorIcmsSt.Arredondar());
        }

        [Fact]
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

            Assert.Equal(5.53m, csosn900.ValorIcmsSt.Arredondar());
        }

        [Fact]
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

            Assert.Equal(61.19m, csosn900.ValorBcIcmsSt.Arredondar());
        }
    }
}