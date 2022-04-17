using System;
using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst51Test
    {
        [Fact]
        public void CalculoCST51()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 1000.00m,
                PercentualIcms = 18.00m,
                PercentualDiferimento = 33.33m

            };

            var cst = new Cst51();
            cst.Calcula(produto);

           
            Assert.Equal(1000.00m, cst.ValorBcIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(180.00m, cst.ValorIcmsOperacao);
            Assert.Equal(33.33m, cst.PercentualDiferimento);
            Assert.Equal(60.00m, Math.Round(cst.ValorIcmsDiferido, MidpointRounding.AwayFromZero));
            Assert.Equal(120.00m, Math.Round(cst.ValorIcms, MidpointRounding.AwayFromZero));
        }

   
    }
}
