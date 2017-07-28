using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn400 : CsosnBase
    {
        public Csosn400(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn400;
        }
    }
}