using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Facade;
using MotorTributarioNet.Impostos.Implementacoes;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoDifalFcpTest
    {

        [TestMethod]
        public void CalculaDifalJuntoComFcp()
        {
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

            Assert.AreEqual(1000.00m, resultadoCalculoDifal.BaseCalculo);
            Assert.AreEqual(20.00m, resultadoCalculoDifal.Fcp);
            Assert.AreEqual(60.00m, resultadoCalculoDifal.Difal);
            Assert.AreEqual(00.00m, resultadoCalculoDifal.ValorIcmsOrigem);
            Assert.AreEqual(60.00m, resultadoCalculoDifal.ValorIcmsDestino);
            Assert.AreEqual("Valores totais do ICMS interstadual: DIFAL da UF destino 60,00 + FCP 20,00; DIFAL da UF Origem 0,00",
                resultadoCalculoDifal.GetObservacao(new DadosMensagemDifal(decimal.Round(resultadoCalculoDifal.Fcp, 2), 
                    decimal.Round(resultadoCalculoDifal.ValorIcmsDestino, 2),
                    decimal.Round(resultadoCalculoDifal.ValorIcmsOrigem, 2))));

            Assert.AreEqual("Valores totais do ICMS interstadual: DIFAL da UF destino 60,00 + FCP 20,00; DIFAL da UF Origem 0,00",
                ResultadoCalculoDifal.GetObservacaoDifal(new DadosMensagemDifal(decimal.Round(resultadoCalculoDifal.Fcp, 2),
                    decimal.Round(resultadoCalculoDifal.ValorIcmsDestino, 2),
                    decimal.Round(resultadoCalculoDifal.ValorIcmsOrigem, 2))));
        }
    }
}