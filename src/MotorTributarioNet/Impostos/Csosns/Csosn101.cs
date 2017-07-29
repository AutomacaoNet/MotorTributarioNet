using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn101 : CsosnBase
    {
        public Csosn101(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn101;
        }

        public decimal PercentualCredito { get; private set; }

        public decimal ValorCredito { get; private set; }

        public override void Calcula(ITributavel tributavel)
        {
            var resultadoCalculoIcmsCredito = new FacadeCalculadoraTributacao(tributavel).CalculaIcmsCredito();

            PercentualCredito = tributavel.PercentualCredito;
            ValorCredito = resultadoCalculoIcmsCredito.Valor;
        }
    }
}