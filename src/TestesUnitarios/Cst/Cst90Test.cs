using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using MotorTributarioNet.Flags;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst90Test
    {
        [Fact]
        public void CalculoCst90ICMSProprio()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 100.00m,                
                PercentualIcms = 18.00m,
                PercentualReducao = 10.00m
            };


            var cst = new Cst90();
            cst.Calcula(produto);

            Assert.Equal(ModalidadeDeterminacaoBcIcms.ValorOperacao, cst.ModalidadeDeterminacaoBcIcms);
            Assert.Equal(90.00m, cst.ValorBcIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(16.20m, cst.ValorIcms);
        }

        [Fact]
        public void CalculoCst90ICMSST()
        {
            var produto = new Produto
            {

                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualReducao = 10.00m,
                PercentualReducaoSt = 10.00m,
                PercentualMva = 100.00m,
                ValorProduto = 100.00m,
                QuantidadeProduto = 1.000m

            };

            var cst = new Cst90();
            cst.Calcula(produto);

            Assert.Equal(ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado, cst.ModalidadeDeterminacaoBcIcmsSt);
            Assert.Equal(100.00m, cst.PercentualMva);
            Assert.Equal(10.00m, cst.PercentualReducaoSt);
            Assert.Equal(18.00m, cst.PercentualIcmsSt);
            Assert.Equal(90.00m, cst.ValorBcIcms);
            Assert.Equal(16.20m, cst.ValorIcmsSt);
            Assert.Equal(180.00m, cst.ValorBcIcmsSt);
            Assert.Equal(16.20m, cst.ValorIcmsSt);
        }

        [Fact]
        public void CalculaCST90_CTe()
        {
            var produtoFrete = new Produto
            {
                Documento = Documento.CTe,
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                PercentualCredito = 20.00m
            };

            var cst = new Cst90();
            cst.Calcula(produtoFrete);

            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(1000.00m, cst.ValorBcIcms);
            Assert.Equal(36.00m, cst.ValorCredito);
        }
    }
}
