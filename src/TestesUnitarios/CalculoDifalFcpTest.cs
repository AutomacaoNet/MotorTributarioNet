using System.Globalization;
using System.Threading;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Impostos.Implementacoes;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoDifalFcpTest
    {

        [Fact]
        public void CalculaDifalJuntoComFcp()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            var produto = new Produto
            {
                ValorProduto = 845.00m,
                QuantidadeProduto = 1.000m,
                Frete = 35.00m,
                OutrasDespesas = 80.00m,
                Desconto = 10.00m,
                ValorIpi = 50.00m,
                PercentualFcp = 02.00m,
                PercentualDifalInterna = 18.00m,
                PercentualDifalInterestadual = 12.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoDifal = facade.CalculaDifalFcp();

            Assert.Equal(1000.00m, resultadoCalculoDifal.BaseCalculo);
            Assert.Equal(20.00m, resultadoCalculoDifal.Fcp);
            Assert.Equal(60.00m, resultadoCalculoDifal.Difal);
            Assert.Equal(00.00m, resultadoCalculoDifal.ValorIcmsOrigem);
            Assert.Equal(60.00m, resultadoCalculoDifal.ValorIcmsDestino);
            Assert.Equal("Valores totais do ICMS interstadual: DIFAL da UF destino 60,00 + FCP 20,00; DIFAL da UF Origem 0,00",
                resultadoCalculoDifal.GetObservacao(new DadosMensagemDifal(decimal.Round(resultadoCalculoDifal.Fcp, 2), 
                    decimal.Round(resultadoCalculoDifal.ValorIcmsDestino, 2),
                    decimal.Round(resultadoCalculoDifal.ValorIcmsOrigem, 2))));

            Assert.Equal("Valores totais do ICMS interstadual: DIFAL da UF destino 60,00 + FCP 20,00; DIFAL da UF Origem 0,00",
                ResultadoCalculoDifal.GetObservacaoDifal(new DadosMensagemDifal(decimal.Round(resultadoCalculoDifal.Fcp, 2),
                    decimal.Round(resultadoCalculoDifal.ValorIcmsDestino, 2),
                    decimal.Round(resultadoCalculoDifal.ValorIcmsOrigem, 2))));
        }
    }
}