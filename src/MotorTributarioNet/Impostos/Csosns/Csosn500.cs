using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn500 : CsosnBase
    {
        public Csosn500(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn500;
        }

        public decimal PercentualBcStRetido { get; set; }
        public decimal ValorBcStRetido { get; set; }
    }
}