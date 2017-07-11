using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn300 : CsosnBase
    {
        public Csosn300(OrigemMercadoria origemMercadoria) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn300;
        }
    }
}