using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst60Test
    {
        [Fact]
        public void CalculaCst60()
        {
            var produto = new Produto
            {
                Documento = Documento.NFe,
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcmsSt = 18.00m,
            };

            var cst = new Cst60();
            cst.Calcula(produto);

            Assert.Equal(18.00m, cst.PercentualBcStRetido);
            Assert.Equal(1000.00m, cst.ValorBcStRetido);
        }

        [Fact]
        public void CalculaCST60_CTe()
        {
            var produtoFrete = new Produto
            {
                Documento = Documento.CTe,
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcmsSt = 18.00m,
                PercentualCredito = 20.00m
            };

            var cst = new Cst60();
            cst.Calcula(produtoFrete);

            Assert.Equal(18.00m, cst.PercentualBcStRetido);
            Assert.Equal(1000.00m, cst.ValorBcStRetido);
            Assert.Equal(36.00m, cst.ValorCreditoOutorgadoOuPresumido);
        }

        [Fact]
        public void CalculaCST60_ICMSEfetivo()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcmsEfetivo = 18.00m,
                PercentualReducaoIcmsEfetivo = 20.00m,
                PercentualFcpStRetido = 2.00m
            };

            var cst60 = new Cst60();

            cst60.Calcula(produto);

            Assert.Equal(800.00m, cst60.ValorBcIcmsEfetivo);
            Assert.Equal(160.00m, cst60.ValorIcmsEfetivo);
        }
    }
}