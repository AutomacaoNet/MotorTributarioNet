using MotorTributarioNet.Facade;

namespace MotorTributarioNet.Impostos.Csosns.Extensao
{
    public static class ExtCsosn101
    {
        public static void Calcula(this Csosn101 csosn101, ITributavel tributavel)
        {
            tributavel.PercentualCredito = csosn101.PercentualCredito;

            var resultadoCalculoIcmsCredito = new FacadeCalculadoraTributacao(tributavel).CalculaIcmsCredito();

            csosn101.ValorCredito = resultadoCalculoIcmsCredito.Valor;
        }
    }
}